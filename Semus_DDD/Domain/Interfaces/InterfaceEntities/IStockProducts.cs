using Domain.Interfaces.Generics;
using Entities.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceEntities
{
    public interface IStockProducts : IGeneric<StockProducts>
    {
        Task<List<StockProducts>> ListByStock(int stockID, byte type);
        Task<List<StockProducts>> ListByType(byte type);
    }
}
