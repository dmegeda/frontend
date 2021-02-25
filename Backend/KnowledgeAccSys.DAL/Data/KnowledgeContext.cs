using KnowledgeAccSys.DAL.Abstracts;
using KnowledgeAccSys.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeAccSys.DAL.Data
{
    public class KnowledgeContext : IdentityDbContext<IdentityUser>, IDataContext
    {
        public DbSet<Report> Reports { get; set; }
        public DbSet<Statistic> Statistics { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestQuestion> Questions { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public KnowledgeContext(DbContextOptions<KnowledgeContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }

        //public KnowledgeContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseLazyLoadingProxies();
            options.UseSqlServer("Server=DIMA-LAPTOP\\SQLEXPRESS;Database=KnowledgeDB;Integrated Security=true;");       
        }

        private void SeedData()
        {
            Answer a1 = new Answer() { Text = "List" };
            Answer a2 = new Answer() { Text = "ArrayList" };
            Answer a3 = new Answer() { Text = "Enum" };
            Answer a4 = new Answer() { Text = "True" };
            Answer a5 = new Answer() { Text = "False" };
            Answer a6 = new Answer() { Text = "Top-most element of the Stack can be " +
                "accessed using the Peek() method" };
            Answer a7 = new Answer() { Text = "It is used to maintain a FIFO list" };
            Answers.AddRange(a1, a2, a3, a4, a5, a6, a7);
            SaveChanges();

            TestQuestion q1 = new TestQuestion()
            {
                AnswerId = a3.Id,
                Answers = new List<Answer>() { a1, a2, a3 },
                Text = "What is NOT a collection?"
            };
            TestQuestion q2 = new TestQuestion()
            {
                AnswerId = a4.Id,
                Answers = new List<Answer>() { a4, a5 },
                Text = "In a HashTable Key cannot be null, but Value can be."
            };

            TestQuestion q3 = new TestQuestion()
            {
                AnswerId = a6.Id,
                Answers = new List<Answer>() { a6, a7 },
                Text = "Which of the following statements are correct about the Stack?"
            };
            Questions.AddRange(q1, q2, q3);
            SaveChanges();

            Theme th1 = new Theme() { Title = "Collections" };
            Themes.Add(th1);
            SaveChanges();

            Test t1 = new Test()
            {
                Description = "Test about collections",
                StartDate = DateTime.Now,
                Deadline = DateTime.Now.AddDays(30),
                MaxRate = 100,
                MinRatingForPass = 80,
                Questions = new List<TestQuestion>() { q1, q2, q3 },
                Theme = th1,
                Title = "Collections Test"
            };
            Tests.Add(t1);
            SaveChanges();
        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }
    }
}
