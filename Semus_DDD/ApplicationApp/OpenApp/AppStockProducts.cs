using ApplicationApp.Interfaces;
using Domain.Interfaces.InterfaceEntities;
using Entities.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationApp.OpenApp
{
    public class AppStockProducts : IStockProductsApp
    {
        private readonly IStockProducts _IStockProducts;

        public AppStockProducts(IStockProducts IStockProducts)
        {
            _IStockProducts = IStockProducts;
        }

        #region Methods
        public async Task Add(StockProducts Object)
        {
            await _IStockProducts.Add(Object);
        }

        public async Task Delete(StockProducts Object)
        {
            await _IStockProducts.Delete(Object);
        }

        public async Task<StockProducts> GetEntityById(int Id)
        {
            return await _IStockProducts.GetEntityById(Id);
        }

        public async Task<List<StockProducts>> List()
        {
            return await _IStockProducts.List();
        }

        public async Task Update(StockProducts Object)
        {
            await _IStockProducts.Update(Object);
        }
        #endregion
    }
}
