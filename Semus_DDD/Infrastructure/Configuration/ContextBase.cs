using Entities.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration
{
    public class ContextBase : DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
            _ = Database.EnsureCreated();
        }

        public DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
            base.OnConfiguring(optionsBuilder);
        }

        private string GetConnectionString()
        {
            return "Data Source=DESKTOP-Q0QSRSM\\SQLEXPRESS;Initial Catalog=DDD_Semus;Integrated Security=True;User ID=sa;Password=123";
        }
    }
}
