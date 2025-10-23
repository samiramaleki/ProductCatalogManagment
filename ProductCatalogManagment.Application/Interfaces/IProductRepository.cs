using Microsoft.EntityFrameworkCore;
using ProductCatalogManagment.Domain;

namespace ProductCatalogManagment.Application.Interfaces
{
    public interface IProductRepository:IRepository<Product, int>
    {
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
