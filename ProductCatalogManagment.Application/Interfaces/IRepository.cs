namespace ProductCatalogManagment.Application.Interfaces
{
    public interface IRepository<TEntity, TKey>
    {
        Task<TKey> Create(TEntity model);
        Task<TKey> Update(TEntity model);
        Task Delete(TEntity model);
        Task<TEntity?> GetById(TKey id);
    }
}
