using Domain.Interfaces.Generics;
using Entities.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceEntities
{
    public interface IProduct : IGeneric<Product>
    {
        Task<List<Product>> ListByType(byte type);
    }
}
