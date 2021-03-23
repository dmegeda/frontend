using KnowledgeAccSys.DAL.Abstracts;
using KnowledgeAccSys.DAL.Abstracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KnowledgeAccSys.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        readonly IDataContext _context;
        readonly DbSet<TEntity> _dbSet;

        public GenericRepository(IDataContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity item)
        {
            if (item != null) _dbSet.Add(item);
        }

        public async Task AddAsync(TEntity item)
        {
            if (item != null) await _dbSet.AddAsync(item);
        }

        public void Delete(int id)
        {
            TEntity entity = GetById(id);
            if (entity != null) _dbSet.Remove(entity);
        }

        public async Task DeleteAsync(int id)
        {
            TEntity entity = await GetByIdAsync(id);
            if (entity != null) _dbSet.Remove(entity);
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return _dbSet.ToList().Where(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.ToList().Find(x => x.Id == id);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(TEntity item)
        {
            _dbSet.Attach(item);
            ((DbContext)_context).Entry(item).State = EntityState.Modified;
        }
    }
}
