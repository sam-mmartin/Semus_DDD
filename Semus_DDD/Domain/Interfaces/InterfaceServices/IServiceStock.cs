using Entities.Entity;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IServiceStock
    {
        Task AddStock(Stock stock);
    }
}
