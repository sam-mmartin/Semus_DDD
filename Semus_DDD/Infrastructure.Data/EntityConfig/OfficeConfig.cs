using Entities.Entity.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfig
{
    public class OfficeConfig : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            _ = builder.ToTable("Funcao");
            _ = builder.Property(p => p.Description).IsRequired().HasMaxLength(50);
        }
    }
}
