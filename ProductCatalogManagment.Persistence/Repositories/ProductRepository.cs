using Microsoft.EntityFrameworkCore;
using ProductCatalogManagment.Application.Interfaces;
using ProductCatalogManagment.Domain;
using ProductCatalogManagment.Domain.Dtos.Products;
using ProductCatalogManagment.Persistence.EF;
using System.Threading;

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

        public async Task Delete(Product model)
        {
            await Task.FromResult(_context.Products.Remove(model));
        }

        public async Task<Product?> GetById(int id)
        {
            return await _context.Products.Include(x => x.Children).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> Update(Product model)
        {
            await Task.FromResult(_context.Products.Update(model));
            return model.Id;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
           => await _context.SaveChangesAsync(cancellationToken);

        public async Task<Product?> GetByParentIdAsync(int parentId, CancellationToken cancellationToken)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == parentId);
        }

        public async Task<List<ProductListOutputDto>> GetProductListsAsync(CancellationToken cancellationToken = default)
        {
            var productsFlat = await _context.Products
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            var dict = productsFlat.ToDictionary(p => p.Id);

            foreach (var p in productsFlat)
            {
                if (p.ParentId.HasValue && dict.ContainsKey(p.ParentId.Value))
                {
                    var parent = dict[p.ParentId.Value];
                    parent.Children ??= new List<Product>();
                    parent.Children.Add(p);
                }
            }

            var roots = productsFlat.Where(p => p.Level == 1).ToList();

            return roots.Select(MapToDto).ToList();
        }

        private ProductListOutputDto MapToDto(Product product)
        {
            return new ProductListOutputDto
            {
                Id = product.Id,
                Name = product.Name,
                Level = product.Level,
                Price = product.Price,
                Quantity = product.Quantity,
                Children = product.Children.Select(MapToDto).ToList()
            };
        }

        public async Task<int> GetMaxLevelByParentId(int parentId, CancellationToken cancellationToken)
        {
            var parent = await _context.Products.Include(x => x.Children).AsNoTracking().FirstOrDefaultAsync(x => x.Id == parentId, cancellationToken);

            if (parent is not null)
            {
                var maxLevel = parent.Children.Any() ? parent.Children.Max(c => c.Level) : parent.Level;
                return maxLevel;
            }
            else return default;
        }
    }
}
