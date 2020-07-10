using Entities.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfig
{
    public class StockConfig : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            _ = builder.ToTable("Estoque");
            _ = builder.Property(p => p.Description).IsRequired().HasMaxLength(100);
            _ = builder.Property(p => p.DateRegister).IsRequired();
        }
    }
}
