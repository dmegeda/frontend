using KnowledgeAccountingSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeAccountingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        // POST api/<AccountController>/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(UserModel model)
        {
            model.Role = "Student";
            var user = new IdentityUser()
            {
                UserName = model.UserName
            };

            if(await _userManager.FindByNameAsync(user.UserName) != null)
            {
                return BadRequest("It is not unique username!");
            }

            var pwd_validator = new PasswordValidator<IdentityUser>();
            var pwd_result = await pwd_validator.ValidateAsync(_userManager, user, model.Password);

            if (!pwd_result.Succeeded) return BadRequest("Password is invalid!");

            var create_result = await _userManager.CreateAsync(user, model.Password);

            if (create_result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, model.Role);
                return await Login(model);
            }

            return BadRequest("Invalid data!");
        }

        // POST api/<AccountController>/Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if(user == null) return BadRequest("Incorrect username!");
            if(!await _userManager.CheckPasswordAsync(user, model.Password)) 
                return BadRequest("Incorrect password!");

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {       
                var role = await _userManager.GetRolesAsync(user);
                IdentityOptions _options = new IdentityOptions();
                var tokenKey = Encoding.UTF8.GetBytes("cexshh722yDQM7jdGMCswk9Ng");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID", user.Id.ToString()),
                        new Claim("UserName", user.UserName.ToString()),
                        new Claim(_options.ClaimsIdentity.RoleClaimType, role.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);

                return Ok(new { Token = token });
            }

            return BadRequest("Incorrect data!");
        }
    }
}
