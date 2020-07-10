using Entities.Entity.Client;
using Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Configuration
{
    public class IdentityConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            _ = builder
                .Property(user => user.Nome)
                .IsRequired()
                .HasMaxLength(50);

            _ = builder
                .Property(user => user.Endereco)
                .IsRequired()
                .HasMaxLength(100);

            _ = builder
                .Property(user => user.Nascimento)
                .IsRequired();

            _ = builder
                .Property(user => user.OfficeID)
                .IsRequired();

            _ = builder
                .Property(user => user.DepartmentID)
                .IsRequired();

            _ = builder
                .HasOne(s => s.Office)
                .WithMany()
                .HasForeignKey(k => k.OfficeID);

            _ = builder
                .HasOne(s => s.Department)
                .WithMany()
                .HasForeignKey(k => k.DepartmentID);
        }
    }
}
