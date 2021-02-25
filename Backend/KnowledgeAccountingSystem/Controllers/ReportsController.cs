using AutoMapper;
using KnowledgeAccountingSystem.Models;
using KnowledgeAccSys.BLL.Abstracts;
using KnowledgeAccSys.BLL.DI;
using KnowledgeAccSys.BLL.DTO;
using KnowledgeAccSys.BLL.Services;
using Microsoft.AspNetCore.Http;
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
    public class ReportsController : ControllerBase
    {
        readonly IKernel kernel;
        readonly IReportService reportService;
        readonly IService<TestDTO> testsService;

        public ReportsController()
        {
            kernel = new StandardKernel(new NinjectServiceModule());
            reportService = kernel.Get<ReportsService>();
            testsService = kernel.Get<TestsService>();
        }

        [HttpGet("{test_id}")]
        public async Task<IActionResult> GenerateReport(string test_id)
        {
            if(int.TryParse(test_id, out int testIdInt) 
                && await testsService.GetByIdAsync(testIdInt) != null)
            {
                int usersCount = reportService.GetAllTestingUsersCount(testIdInt);
                double avg = reportService.GetAvgRate(testIdInt);
                int passedCount = reportService.GetPassedCount(testIdInt);

                ReportDTO report = new ReportDTO()
                {
                    AllTestingUser = usersCount,
                    AvgRate = avg,
                    PassedUserCount = passedCount,
                    TestId = testIdInt,
                    CreateDate = DateTime.Now
                };

                var mapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ReportDTO, ReportModel>();
                }).CreateMapper();
                ReportModel model = mapper.Map<ReportDTO, ReportModel>(report);

                await reportService.AddAsync(report);
                return Ok(new { model });
            }
            return BadRequest("Wrong id!");
        }
    }
}
