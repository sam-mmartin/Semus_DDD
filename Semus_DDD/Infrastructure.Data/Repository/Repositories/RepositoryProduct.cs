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
    public class RepositoryProduct : RepositoryGeneric<Product>, IProduct
    {
        private readonly DbContextOptions<ContextBase> _OptionBuilder;

        public RepositoryProduct()
        {
            _OptionBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Product>> ListByType(byte type)
        {
            using ContextBase data = new ContextBase(_OptionBuilder);
            return await data.Set<Product>()
                .Where(p => p.Type == type)
                .Include(s => s.StockProducts)
                .ThenInclude(t => t.Stock)
                .ToListAsync();
        }
    }
}
