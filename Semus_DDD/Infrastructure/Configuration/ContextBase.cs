using Entities.Entity;
using Infrastructure.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration
{
    public class ContextBase : DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<StockProducts> StockProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.ApplyConfiguration(new ProductConfig());
            _ = modelBuilder.ApplyConfiguration(new StockConfig());
            _ = modelBuilder.ApplyConfiguration(new StockProductsConfig());
        }

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
