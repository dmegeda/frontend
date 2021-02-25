using KnowledgeAccSys.DAL.Abstracts.Repositories;
using KnowledgeAccSys.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeAccSys.DAL.Abstracts
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Report> Reports { get; }
        IGenericRepository<Statistic> Statistics { get; }
        IGenericRepository<TestQuestion> Questions { get; }
        IGenericRepository<Test> Tests { get; }
        IGenericRepository<Theme> Themes { get; }
        IGenericRepository<Answer> Answers { get; }

        void Save();
        Task SaveAsync();
    }
}
