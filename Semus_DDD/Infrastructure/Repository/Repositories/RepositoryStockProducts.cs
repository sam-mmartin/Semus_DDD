using Domain.Interfaces.InterfaceEntities;
using Entities.Entity;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryStockProducts : RepositoryGeneric<StockProducts>, IStockProducts
    {
        private readonly DbContextOptions<ContextBase> _OptionBuilder;

        public RepositoryStockProducts()
        {
            _OptionBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<StockProducts>> ListByStock(int stockID, byte type)
        {
            using ContextBase data = new ContextBase(_OptionBuilder);
            return await data.Set<StockProducts>()
                .Where(s => s.StockID == stockID && s.Product.Type == type)
                .Include(p => p.Product)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<StockProducts>> ListByType(byte type)
        {
            using ContextBase data = new ContextBase(_OptionBuilder);
            return await data.Set<StockProducts>()
                .Where(s => s.Product.Type == type)
                .Include(p => p.Product)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
