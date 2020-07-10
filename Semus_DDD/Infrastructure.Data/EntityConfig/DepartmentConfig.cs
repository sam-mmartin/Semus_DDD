using Entities.Entity.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfig
{
    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            _ = builder.ToTable("Setor");
            _ = builder.Property(p => p.Description).IsRequired().HasMaxLength(50);
        }
    }
}
