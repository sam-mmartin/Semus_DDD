using ApplicationApp.Interfaces.Generics;
using Entities.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationApp.Interfaces
{
    public interface IStockProductsApp : IGenericApp<StockProducts>
    {
        Task<List<StockProducts>> ListByStock(int stockID, byte type);
        Task<List<StockProducts>> ListByType(byte type);
    }
}
