using KnowledgeAccSys.DAL.Abstracts;
using KnowledgeAccSys.DAL.Abstracts.Repositories;
using KnowledgeAccSys.DAL.Entities;
using KnowledgeAccSys.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace KnowledgeAccSys.DAL.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly IDataContext db;

        IGenericRepository<Report> reports;
        IGenericRepository<Statistic> statistics;
        IGenericRepository<TestQuestion> questions;
        IGenericRepository<Test> tests;
        IGenericRepository<Theme> themes;
        IGenericRepository<Answer> answers;

        public UnitOfWork(IDataContext context)
        {
            db = context;
        }

        public IDataContext GetContext()
        {
            return db;
        }

        public IGenericRepository<Report> Reports
        {
            get
            {
                if (reports == null) reports = new GenericRepository<Report>(db);
                return reports;
            }
        }

        public IGenericRepository<Statistic> Statistics
        {
            get
            {
                if (statistics == null) statistics = new GenericRepository<Statistic>(db);
                return statistics;
            }
        }

        public IGenericRepository<TestQuestion> Questions
        {
            get
            {
                if (questions == null) questions = new GenericRepository<TestQuestion>(db);
                return questions;
            }
        }

        public IGenericRepository<Test> Tests
        {
            get
            {
                if (tests == null) tests = new GenericRepository<Test>(db);
                return tests;
            }
        }

        public IGenericRepository<Theme> Themes
        {
            get
            {
                if (themes == null) themes = new GenericRepository<Theme>(db);
                return themes;
            }
        }

        public IGenericRepository<Answer> Answers
        {
            get
            {
                if (answers == null) answers = new GenericRepository<Answer>(db);
                return answers;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing) ((DbContext)db).Dispose();
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            ((DbContext)db).SaveChanges();
        }

        public async Task SaveAsync()
        {
            await ((DbContext)db).SaveChangesAsync();
        }
    }
}
