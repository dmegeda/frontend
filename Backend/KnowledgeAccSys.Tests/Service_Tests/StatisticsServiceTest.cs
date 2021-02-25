using KnowledgeAccSys.BLL.Abstracts;
using KnowledgeAccSys.BLL.Services;
using KnowledgeAccSys.DAL.Abstracts;
using KnowledgeAccSys.DAL.Abstracts.Repositories;
using KnowledgeAccSys.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeAccSys.Tests.Service_Tests
{
    [TestFixture]
    public class StatisticsServiceTest
    {
        IStatisticService _statisticService;
        Mock<IGenericRepository<Statistic>> _repository;

        [SetUp]
        public void Setup()
        {
            var questionsList = new List<TestQuestion>()
            {
                new TestQuestion(), new TestQuestion(), new TestQuestion()
            };

            IQueryable<Test> tests = new List<Test>()
            {
                new Test(){Id = 1, MinRatingForPass = 50, MaxRate = 120, Questions = questionsList},
                new Test(){Id = 2, MinRatingForPass = 70, MaxRate = 120, Questions = questionsList},
                new Test(){Id = 3, MinRatingForPass = 75, MaxRate = 100, Questions = new List<TestQuestion>()}
            }
            .AsQueryable();

            var dbSet = new Mock<DbSet<Test>>();
            dbSet.As<IQueryable<Test>>().Setup(x => x.Provider).Returns(tests.Provider);
            dbSet.As<IQueryable<Test>>().Setup(x => x.Expression).Returns(tests.Expression);
            dbSet.As<IQueryable<Test>>().Setup(x => x.ElementType).Returns(tests.ElementType);
            dbSet.As<IQueryable<Test>>().Setup(x => x.GetEnumerator()).Returns(tests.GetEnumerator());
            dbSet.As<IQueryable<Test>>().Setup(x => x.Provider).Returns(tests.Provider);
            var mockDbContext = new Mock<IDataContext>();

            mockDbContext.Setup(x => x.Set<Test>()).Returns(dbSet.Object);

            var mockTestRepository = new Mock<IGenericRepository<Test>>();
            mockTestRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int x) => tests.ToList().Find(t => t.Id == x));

            _repository = new Mock<IGenericRepository<Statistic>>();

            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.Setup(x => x.Tests).Returns(mockTestRepository.Object);
            mockUOW.Setup(x => x.Statistics).Returns(_repository.Object);

            _statisticService = new StatisticsService(mockUOW.Object);
        }

        [Test]
        [Timeout(1000)]
        public void AddTest_AddNullItem_RepositoryMethodNotInvoked()
        {
            _statisticService.Add(null);

            _repository.Verify(x => x.Add(null), Times.Never);
        }

        [Test]
        [Timeout(1000)]
        public async Task AddAsyncTest_AddNullItem_RepositoryMethodNotInvoked()
        {
            await _statisticService.AddAsync(null);

            _repository.Verify(x => x.AddAsync(null), Times.Never);
        }

        [Test]
        [Timeout(1000)]
        public void UpdateTest_UpdateNullItem_RepositoryMethodNotInvoked()
        {
            _statisticService.Update(null);

            _repository.Verify(x => x.Update(null), Times.Never);
        }

        [TestCase(1, 3, 120)]
        [TestCase(2, 1, 40)]
        [TestCase(3, 0, 0)]
        [TestCase(3, 100, 0)]
        [Timeout(1000)]
        public async Task CalculateUserRatingTest_DifferentConditions_ReturnValueAsExpected(int testId, 
            int correctCount, double expectedResult)
        {
            var actualResult = await _statisticService.CalculateUserRating(correctCount, testId);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(10, 60, false)]
        [TestCase(99, -1, false)]
        [TestCase(-99, 1, false)]
        [TestCase(98, 97, true)]
        [Timeout(1000)]
        public void CheckIsPassedTest_DifferentConditions_ReturnValueAsExprected(double userRating,
            double minRate, bool expected)
        {
            var actual = _statisticService.CheckTestIsPassed(userRating, minRate);

            Assert.AreEqual(expected, actual);
        }
    }
}
