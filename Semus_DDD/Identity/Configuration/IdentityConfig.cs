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
        }
    }
}
