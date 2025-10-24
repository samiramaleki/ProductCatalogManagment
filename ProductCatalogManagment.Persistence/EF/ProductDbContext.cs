using Microsoft.EntityFrameworkCore;
using ProductCatalogManagment.Domain;
using ProductCatalogManagment.Domain.Models;
using ProductCatalogManagment.Infrastructure.Configuration;

namespace ProductCatalogManagment.Persistence.EF;

public class ProductDbContext: DbContext
{
    private readonly AuditInterceptor _auditInterceptor;

    public ProductDbContext()
    {
        
    }

    public ProductDbContext(DbContextOptions<ProductDbContext> options, AuditInterceptor auditInterceptor) : base(options)
    {
        _auditInterceptor = auditInterceptor;
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=192.168.43.206,5003;Database=ProductCatalog;uid=sa;pwd=D9OUXpYkiWeOAZ9m21HU;Encrypt=True;TrustServerCertificate=True");
        optionsBuilder.AddInterceptors(_auditInterceptor);
    }
}
