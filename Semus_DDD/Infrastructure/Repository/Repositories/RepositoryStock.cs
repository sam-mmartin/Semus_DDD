using Domain.Interfaces.InterfaceEntities;
using Entities.Entity;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryStock : RepositoryGeneric<Stock>, IStock
    {
        private readonly DbContextOptions<ContextBase> _OptionBuilder;

        public RepositoryStock()
        {
            _OptionBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<Stock> GetById(int id)
        {
            using ContextBase data = new ContextBase(_OptionBuilder);
            return await data.Set<Stock>()
                .Where(s => s.ID == id)
                .Include(s => s.StockProducts).ThenInclude(p => p.Product)
                .SingleOrDefaultAsync();
        }
    }
}
