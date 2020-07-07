using Domain.Interfaces.InterfaceEntities;
using Domain.Interfaces.InterfaceServices;
using Entities.Entity;
using System;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceStock : IServiceStock
    {
        private readonly IStock _IStock;

        public ServiceStock(IStock IStock)
        {
            _IStock = IStock;
        }

        public async Task AddStock(Stock stock)
        {
            stock.DateRegister = DateTime.Now;
            stock.DateUpdate = DateTime.Now;
            await _IStock.Add(stock);
        }
    }
}
