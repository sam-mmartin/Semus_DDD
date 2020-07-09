using ApplicationApp.Interfaces.Generics;
using Entities.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationApp.Interfaces
{
    public interface IProductApp : IGenericApp<Product>
    {
        Task<List<Product>> ListByType(byte type);
    }
}
