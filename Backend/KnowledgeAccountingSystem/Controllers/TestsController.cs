using KnowledgeAccountingSystem.Models;
using KnowledgeAccSys.BLL.Abstracts;
using KnowledgeAccSys.BLL.DI;
using KnowledgeAccSys.BLL.DTO;
using KnowledgeAccSys.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Ninject;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeAccountingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        readonly IKernel _kernel;
        readonly IService<TestDTO> _testsService;

        public TestsController()
        {
            _kernel = new StandardKernel(new NinjectServiceModule());
            _testsService = _kernel.Get<TestsService>();
        }

        // GET: api/<TestController>
        [HttpGet]
        public async Task<IEnumerable<TestDTO>> GetAllNonDeleted()
        {
            return await _testsService.GetAllAsync();
        }

        [HttpGet]
        [Route("deleted")]
        public async Task<IEnumerable<TestDTO>> GetAllDeleted()
        {
            return await _testsService.GetAllAsync(true);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<TestDTO>> GetAll()
        {
            IEnumerable<TestDTO> testsDeleted = await _testsService.GetAllAsync(true);
            IEnumerable<TestDTO> testsNonDeleted = await _testsService.GetAllAsync();
            List<TestDTO> allTests = testsDeleted.ToList();
            allTests.AddRange(testsNonDeleted.ToList());

            return allTests;
        }

        // GET api/<TestController>/5
        [HttpGet("{test_id}")]
        public async Task<IActionResult> GetById(string test_id)
        {
            if(int.TryParse(test_id, out int parsed_test_id))
            {
                var test = await _testsService.GetByIdAsync(parsed_test_id);
                if (test != null) return Ok(test);

                return BadRequest("Test not found!");
            }
            
            return BadRequest("Wrong identifier!");
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(TestModel testModel)
        {
            TestDTO test = await _testsService.GetByIdAsync(testModel.Id);

            if (test != null)
            {
                test.Title = testModel.Title;
                _testsService.Update(test);

                return Ok("Success!");
            }

            return BadRequest("Test not found!");
        }

        [HttpPut]
        [Route("delete/soft/{test_id}")]
        public async Task<IActionResult> SoftDelete(string test_id)
        {
            if (int.TryParse(test_id, out int test_id_parsed))
            {
                TestDTO test = await _testsService.GetByIdAsync(test_id_parsed);

                if (test != null)
                {
                    if (test.IsDeleted) return BadRequest("Test already deleted!");

                    test.IsDeleted = true;
                    _testsService.Update(test);

                    return Ok("Success!");
                }

                return BadRequest("Test not found!");
            }

            return BadRequest("Wrong identifier!");
        }

        [HttpDelete]
        [Route("delete/permanent/{test_id}")]
        public async Task<IActionResult> DeleteFromDatabase(string test_id)
        {
            if (int.TryParse(test_id, out int test_id_parsed))
            {
                TestDTO test = await _testsService.GetByIdAsync(test_id_parsed);

                if (test != null)
                {
                    await _testsService.DeleteAsync(test.Id);

                    return Ok("Success!");
                }

                return BadRequest("Test not found!");
            }

            return BadRequest("Wrong identifier!");
        }
    }
}
