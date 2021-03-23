using KnowledgeAccountingSystem.Models;
using KnowledgeAccSys.BLL.Abstracts;
using KnowledgeAccSys.BLL.DI;
using KnowledgeAccSys.BLL.DTO;
using KnowledgeAccSys.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Ninject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeAccountingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThemeController : Controller
    {
        readonly IKernel _kernel;
        readonly IService<ThemeDTO> _themeService;

        public ThemeController()
        {
            _kernel = new StandardKernel(new NinjectServiceModule());
            _themeService = _kernel.Get<ThemesService>();
        }

        [HttpGet]
        public async Task<IEnumerable<ThemeDTO>> GetAllNonDeleted()
        {
            return await _themeService.GetAllAsync();
        }

        [HttpGet]
        [Route("deleted")]
        public async Task<IEnumerable<ThemeDTO>> GetAllDeleted()
        {
            return await _themeService.GetAllAsync(true);
        }

        [HttpGet("{theme_id}")]
        public async Task<IActionResult> GetById(string theme_id)
        {
            if(int.TryParse(theme_id, out int theme_id_parsed))
            {
                ThemeDTO theme = await _themeService.GetByIdAsync(theme_id_parsed);

                if(theme != null) return Ok(theme);

                return BadRequest("Theme not found!");
            }

            return BadRequest("Wrong identifier!");
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(ThemeModel themeModel)
        {
            ThemeDTO theme = await _themeService.GetByIdAsync(themeModel.Id);

            if(theme != null)
            {
                theme.Title = themeModel.Title;
                _themeService.Update(theme);

                return Ok("Success!");
            }

            return BadRequest("Theme not found!");
        }

        [HttpPut]
        [Route("delete/soft/{theme_id}")]
        public async Task<IActionResult> SoftDelete(string theme_id)
        {
            if (int.TryParse(theme_id, out int theme_id_parsed))
            {
                ThemeDTO theme = await _themeService.GetByIdAsync(theme_id_parsed);

                if (theme != null)
                {
                    if (theme.IsDeleted) return BadRequest("Theme already deleted!");

                    theme.IsDeleted = true;
                    _themeService.Update(theme);

                    return Ok("Success!");
                }

                return BadRequest("Theme not found!");
            }

            return BadRequest("Wrong identifier!");
        }

        [HttpDelete]
        [Route("delete/permanent/{theme_id}")]
        public async Task<IActionResult> DeleteFromDatabase(string theme_id)
        {
            if (int.TryParse(theme_id, out int theme_id_parsed))
            {
                ThemeDTO theme = await _themeService.GetByIdAsync(theme_id_parsed);

                if (theme != null)
                {
                    await _themeService.DeleteAsync(theme.Id);

                    return Ok("Success!");
                }

                return BadRequest("Theme not found!");
            }

            return BadRequest("Wrong identifier!");
        }
    }
}
