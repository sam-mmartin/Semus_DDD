using Entities.Entity;
using Entities.Entity.Client;
using Infrastructure.EntityConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.Configuration
{
    public class ContextBase : DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Office> Office { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<StockProducts> StockProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.ApplyConfiguration(new DepartmentConfig());
            _ = modelBuilder.ApplyConfiguration(new OfficeConfig());
            _ = modelBuilder.ApplyConfiguration(new ProductConfig());
            _ = modelBuilder.ApplyConfiguration(new StockConfig());
            _ = modelBuilder.ApplyConfiguration(new StockProductsConfig());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                _ = optionsBuilder
                    .UseLazyLoadingProxies()
                    .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.DetachedLazyLoadingWarning))
                    .UseSqlServer(GetConnectionString());
            }

            base.OnConfiguring(optionsBuilder);
        }

        private string GetConnectionString()
        {
            // Laptop
            return "Data Source=DESKTOP-A87BRQ8\\SQLEXPRESS;Initial Catalog=DDD_Semus;Integrated Security=True;User ID=sa;Password=123";
            // Desktop
            //return "Data Source=DESKTOP-Q0QSRSM\\SQLEXPRESS;Initial Catalog=DDD_Semus;Integrated Security=True;User ID=sa;Password=123";
        }
    }
}
