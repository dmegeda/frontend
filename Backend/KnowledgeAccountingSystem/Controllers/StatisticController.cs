using KnowledgeAccountingSystem.Models;
using KnowledgeAccSys.BLL.Abstracts;
using KnowledgeAccSys.BLL.DI;
using KnowledgeAccSys.BLL.DTO;
using KnowledgeAccSys.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeAccountingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        readonly IKernel kernel;
        readonly IStatisticService statsService;
        readonly IService<TestDTO> testService;
        readonly UserManager<IdentityUser> _userManager;

        public StatisticController(UserManager<IdentityUser> userManager)
        {
            kernel = new StandardKernel(new NinjectServiceModule());
            statsService = kernel.Get<StatisticsService>();
            testService = kernel.Get<TestsService>();
            _userManager = userManager;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(StatisticModel model)
        {
            if (model != null && model.CorrectAnswersCount >= 0 && model.User_Id != string.Empty)
            {
                var user = await _userManager.FindByIdAsync(model.User_Id);
                if(user == null)
                {
                    return BadRequest("User not found!");
                }

                var test = await testService.GetByIdAsync(model.Test_Id);
                if(test == null)
                {
                    return BadRequest("Test not found!");
                }

                double userRating = await statsService.CalculateUserRating(model.CorrectAnswersCount, 
                    test.Id);
                bool isPassed = statsService.CheckTestIsPassed(userRating, test.MinRatingForPass);

                StatisticDTO statistic = new StatisticDTO()
                {
                    IsPassed = isPassed,
                    UserId = user.Id,
                    TestId = test.Id,
                    UserRating = userRating
                };

                await statsService.AddAsync(statistic);
                return Ok();
            }

            return BadRequest("Invalid data!");
        }

        // GET api/<TestController>/5
        [HttpGet("{user_id}")]
        public async Task<IActionResult> Get(string user_id)
        {
            var user = await _userManager.FindByIdAsync(user_id);
            if (user != null)
            {
                return Ok(statsService.Find(x => x.UserId == user.Id));
            }
            return BadRequest("User not found!");
        }
    }
}
