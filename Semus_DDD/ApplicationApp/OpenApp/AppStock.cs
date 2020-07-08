using ApplicationApp.Interfaces;
using Domain.Interfaces.InterfaceEntities;
using Domain.Interfaces.InterfaceServices;
using Entities.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationApp.OpenApp
{
    public class AppStock : IStockApp
    {
        private readonly IStock _IStock;
        private readonly IServiceStock _IServiceStock;

        public AppStock(IStock IStock, IServiceStock IServiceStock)
        {
            _IStock = IStock;
            _IServiceStock = IServiceStock;
        }

        #region Methods
        public async Task Add(Stock Object)
        {
            await _IStock.Add(Object);
        }

        public async Task Delete(Stock Object)
        {
            await _IStock.Delete(Object);
        }

        public async Task<Stock> GetEntityById(int Id)
        {
            return await _IStock.GetEntityById(Id);
        }

        public async Task<List<Stock>> List()
        {
            return await _IStock.List();
        }

        public async Task Update(Stock Object)
        {
            await _IStock.Update(Object);
        }
        #endregion

        #region Custom Methods
        public async Task AddStock(Stock stock)
        {
            await _IServiceStock.AddStock(stock);
        }

        public async Task UpdateStock(Stock stock)
        {
            await _IServiceStock.UpdateStock(stock);
        }
        #endregion
    }
}
