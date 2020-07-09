using Domain.Interfaces.Generics;
using Entities.Entity;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceEntities
{
    public interface IStock : IGeneric<Stock>
    {
        Task<Stock> GetById(int id);
    }
}
