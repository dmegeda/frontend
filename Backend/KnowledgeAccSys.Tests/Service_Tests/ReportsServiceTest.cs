using KnowledgeAccSys.BLL.Abstracts;
using KnowledgeAccSys.BLL.DTO;
using KnowledgeAccSys.BLL.Services;
using KnowledgeAccSys.DAL.Abstracts;
using KnowledgeAccSys.DAL.Abstracts.Repositories;
using KnowledgeAccSys.DAL.Entities;
using KnowledgeAccSys.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeAccSys.Tests.Service_Tests
{
    [TestFixture]
    public class ReportsServiceTest
    {
        IReportService _reportService;
        Mock<IGenericRepository<Report>> _repository;

        [SetUp]
        public void Setup()
        {
            IQueryable<Statistic> statistics = new List<Statistic>()
            {
                new Statistic(){Id = 1, UserRating = 55, TestId = 1, IsPassed = false},
                new Statistic(){Id = 2, UserRating = 65, TestId = 1, IsPassed = true},
                new Statistic(){Id = 3, UserRating = 77, TestId = 2, IsPassed = true}
            }
            .AsQueryable();

            var mockStatisticRepository = new Mock<IGenericRepository<Statistic>>();
            mockStatisticRepository.Setup(x => x.Find(It.IsAny<Func<Statistic, bool>>()))
                .Returns((Func<Statistic, bool> x) => statistics.Where(x));

            _repository = new Mock<IGenericRepository<Report>>();

            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.Setup(x => x.Statistics).Returns(mockStatisticRepository.Object);
            mockUOW.Setup(x => x.Reports).Returns(_repository.Object);

            _reportService = new ReportsService(mockUOW.Object);
        }

        [Test]
        [Timeout(1000)]
        public void AddTest_AddNullItem_RepositoryMethodNotInvoked()
        {
            _reportService.Add(null);

            _repository.Verify(x => x.Add(null), Times.Never);
        }

        [Test]
        [Timeout(1000)]
        public async Task AddAsyncTest_AddNullItem_RepositoryMethodNotInvoked()
        {
            await _reportService.AddAsync(null);

            _repository.Verify(x => x.AddAsync(null), Times.Never);
        }

        [Test]
        [Timeout(1000)]
        public void UpdateTest_UpdateNullItem_RepositoryMethodNotInvoked()
        {
            _reportService.Update(null);

            _repository.Verify(x => x.Update(null), Times.Never);
        }

        [TestCase(1, 2)]
        [TestCase(2, 1)]
        [TestCase(99, 0)]
        [Timeout(1000)]
        public void GetAllTestingCountTest_DbSetContainsItems_ReturnValueAsExpected(int testId, 
            int expectedCount)
        {
            var actualCount = _reportService.GetAllTestingUsersCount(testId);

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(1, 60)]
        [TestCase(2, 77)]
        [TestCase(99, 0)]
        [Timeout(1000)]
        public void GetAvgRateTest_DbSetContainsItems_ReturnNotNull(int testId,
            double expectedRate)
        {
            var actualRate = _reportService.GetAvgRate(testId);

            Assert.AreEqual(expectedRate, actualRate);
        }

        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(99, 0)]
        [Timeout(1000)]
        public void GetPassedCountTest_DbSetContainsItems_ReturnNotNull(int testId,
            int expectedCount)
        {
            var actualCount = _reportService.GetPassedCount(testId);

            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
