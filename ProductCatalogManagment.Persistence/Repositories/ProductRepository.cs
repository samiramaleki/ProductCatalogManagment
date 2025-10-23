using ProductCatalogManagment.Application.Interfaces;
using ProductCatalogManagment.Domain;
using ProductCatalogManagment.Persistence.EF;

namespace ProductCatalogManagment.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Product model)
        {
            await _context.Products.AddAsync(model);
            return model.Id;
        }

        public Task Delete(Product model)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Product model)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
           => await _context.SaveChangesAsync(cancellationToken);
    }
}
