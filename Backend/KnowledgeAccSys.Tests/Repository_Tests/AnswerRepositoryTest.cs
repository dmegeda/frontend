using KnowledgeAccSys.DAL.Abstracts;
using KnowledgeAccSys.DAL.Abstracts.Repositories;
using KnowledgeAccSys.DAL.Entities;
using KnowledgeAccSys.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace KnowledgeAccSys.Tests.DAL_Tests
{
    [TestFixture]
    public class AnswerRepositoryTest
    {
        IGenericRepository<Answer> _genericRepository;
        Mock<DbSet<Answer>> _dbSet;

        [SetUp]
        public void Setup()
        {
            IQueryable<Answer> answers = new List<Answer>()
            {
                new Answer(){Id = 1, Text = "Text1"},
                new Answer(){Id = 2, Text = "Text2"},
                new Answer(){Id = 3, Text = "Text3"}
            }
            .AsQueryable();

            _dbSet = new Mock<DbSet<Answer>>();
            _dbSet.As<IQueryable<Answer>>().Setup(x => x.Provider).Returns(answers.Provider);
            _dbSet.As<IQueryable<Answer>>().Setup(x => x.Expression).Returns(answers.Expression);
            _dbSet.As<IQueryable<Answer>>().Setup(x => x.ElementType).Returns(answers.ElementType);
            _dbSet.As<IQueryable<Answer>>().Setup(x => x.GetEnumerator())
                .Returns(answers.GetEnumerator());
            _dbSet.As<IQueryable<Answer>>().Setup(x => x.Provider).Returns(answers.Provider);

            var mockDbContext = new Mock<IDataContext>();
            mockDbContext.Setup(x => x.Set<Answer>()).Returns(_dbSet.Object);

            _genericRepository = new GenericRepository<Answer>(mockDbContext.Object);
        }

        [Test]
        [Timeout(1000)]
        public void GetAllTest_DbSetContainsItems_ReturnNotNull()
        {
            var answers = _genericRepository.GetAll().ToList();

            Assert.IsNotNull(answers);
        }

        [Test]
        [Timeout(1000)]
        public void GetAllTest_DbSetContainsItems_ReturnNotEmptyCollection()
        {
            var answers = _genericRepository.GetAll().ToList();
            var actualCount = answers.Count;

            Assert.IsTrue(actualCount > 0);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [Timeout(1000)]
        public void GetByIdTest_DbSetContainsItemsWithThisId_ReturnNotNull(int id)
        {
            var answer = _genericRepository.GetById(id);

            Assert.IsNotNull(answer);
        }

        [TestCase("Text1")]
        [TestCase("Text2")]
        [TestCase("Text3")]
        [Timeout(1000)]
        public void FindTest_DbSetContainsItemsMatchingPredicate_ReturnNotEmptyCollection(
            string answerText)
        {
            var answers = _genericRepository.Find(x => x.Text == answerText).ToList();

            Assert.IsTrue(answers.Count == 1);
        }

        [TestCase(1, 2)]
        [TestCase(2, 1)]
        [TestCase(3, 0)]
        [Timeout(1000)]
        public void FindTest_DbSetContainsItemsMatchingPredicate_ReturnCollectionCountMoreThan1(int id, 
            int higherIdCount)
        {
            var answers = _genericRepository.Find(x => x.Id > id).ToList();

            Assert.IsTrue(answers.Count == higherIdCount);
        }

        [Test]
        [Timeout(1000)]
        public void AddTest_DbSetContainsItems_DbSetAddMethodInvoked()
        {
            _genericRepository.Add(new Answer() { Id = 4, Text = "Text4"});

            _dbSet.Verify(x => x.Add(It.IsAny<Answer>()), Times.Once);
        }

        [Test]
        [Timeout(1000)]
        public void DeleteTest_DbSetContainsItems_DbSetRemoveMethodInvoked()
        {
            _genericRepository.Delete(1);

            _dbSet.Verify(x => x.Remove(It.IsAny<Answer>()), Times.Once);
        }
    }
}
