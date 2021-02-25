using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeAccSys.DAL.Abstracts.Repositories
{
    public interface IGenericRepositorySync<TEntity> where TEntity: BaseEntity
    {
        IEnumerable<TEntity> GetAll();  
        TEntity GetById(int id);
        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);
        void Add(TEntity item);
        void Update(TEntity item);
        void Delete(int id);
    }
}
