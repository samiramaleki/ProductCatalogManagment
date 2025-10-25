using ProductCatalogManagment.Domain;
using ProductCatalogManagment.Domain.Dtos.Products;

namespace ProductCatalogManagment.Application.Interfaces
{
    public interface IProductRepository : IRepository<Product, int>
    {
        Task<Product?> GetByParentIdAsync(int parentId, CancellationToken cancellationToken = default);
        Task<List<ProductListOutputDto>> GetProductListsAsync(CancellationToken cancellationToken = default);
        Task<int> GetMaxLevelByParentId(int parentId, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
