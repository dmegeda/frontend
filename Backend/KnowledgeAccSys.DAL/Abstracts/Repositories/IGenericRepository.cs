namespace KnowledgeAccSys.DAL.Abstracts.Repositories
{
    public interface IGenericRepository<TEntity> : IGenericRepositorySync<TEntity>, 
        IGenericRepositoryAsync<TEntity> where TEntity: BaseEntity
    {
    }
}
