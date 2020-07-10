using Entities.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfig
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            _ = builder.Property(p => p.Description).IsRequired().HasMaxLength(100);
            _ = builder.Property(p => p.Category).IsRequired().HasMaxLength(50);
            _ = builder.Property(p => p.Type).IsRequired();
        }
    }
}
