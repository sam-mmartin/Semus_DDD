using Entities.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfig
{
    public class StockProductsConfig : IEntityTypeConfiguration<StockProducts>
    {
        public void Configure(EntityTypeBuilder<StockProducts> builder)
        {
            _ = builder.ToTable("EstoqueProdutos");
            _ = builder.HasKey(k => new { k.ProductID, k.StockID });

            _ = builder
                .HasOne(s => s.Stock)
                .WithMany(c => c.StockProducts)
                .HasForeignKey(k => k.StockID);

            _ = builder
                .HasOne(s => s.Product)
                .WithMany(c => c.StockProducts)
                .HasForeignKey(k => k.ProductID);

            _ = builder.Property(p => p.DateInput).IsRequired();
        }
    }
}
