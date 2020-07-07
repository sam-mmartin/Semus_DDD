using Domain.Interfaces.InterfaceEntities;
using Entities.Entity;
using Infrastructure.Repository.Generics;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryProduct : RepositoryGeneric<Product>, IProduct
    {
    }
}
