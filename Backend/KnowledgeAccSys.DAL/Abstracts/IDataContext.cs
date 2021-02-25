using Microsoft.EntityFrameworkCore;

namespace KnowledgeAccSys.DAL.Abstracts
{
    public interface IDataContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
    }
}
