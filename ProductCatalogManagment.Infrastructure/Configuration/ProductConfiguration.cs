using Microsoft.EntityFrameworkCore;
using ProductCatalogManagment.Domain;

namespace ProductCatalogManagment.Infrastructure.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(prop => prop.Id);
        }
    }
}
