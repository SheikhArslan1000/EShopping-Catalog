using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Catalog.Domain.ProductsDetails;

namespace Catalog.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
.Property(p => p.Price)
.HasPrecision(18, 4); // Adjust precision and scale as needed
        }
    }
}
