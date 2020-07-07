using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration
{
    public class ContextBase : DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
            _ = Database.EnsureCreated();
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
            return "Data Source=DESKTOP-A87BRQ8\\SQLEXPRESS;Initial Catalog=BancoSemus;Integrated Security=True";
        }
    }
}
