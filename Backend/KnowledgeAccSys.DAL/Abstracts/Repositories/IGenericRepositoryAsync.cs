using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeAccSys.DAL.Abstracts.Repositories
{
    public interface IGenericRepositoryAsync<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task AddAsync(TEntity item);
        Task DeleteAsync(int id);
    }
}
