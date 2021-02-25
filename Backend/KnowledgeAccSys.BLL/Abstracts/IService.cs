using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeAccSys.BLL.Abstracts
{
    public interface IService<T> where T : BaseDTO
    {
        IEnumerable<T> GetAll(bool isDeleted = false);
        Task<IEnumerable<T>> GetAllAsync(bool isDeleted = false);
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        IEnumerable<T> Find(Func<T, bool> predicate);
        void Add(T item);
        Task AddAsync(T item);
        void Update(T item);
        void Delete(int id);
        Task DeleteAsync(int id);
    }
}
