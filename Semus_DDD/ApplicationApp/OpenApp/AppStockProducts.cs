using ApplicationApp.Interfaces;
using Domain.Interfaces.InterfaceEntities;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationApp.OpenApp
{
    public class AppStockProducts : IStockProductsApp
    {
        private readonly IStockProducts _IStockProducts;

        public AppStockProducts(IStockProducts stockProducts)
        {
            _IStockProducts = stockProducts;
        }

        #region Methods
        public async Task Add(StockProducts Object)
        {
            Object.DateInput = DateTime.Now;
            Object.DateOutput = DateTime.Now;
            Object.QuantityTotal = 0;
            Object.Quant_Input = 0;
            Object.Quant_Output = 0;
            Object.Quant_Shortage = 0;
            Object.StockID = 1;
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

        #region Custom Methods
        public async Task<List<StockProducts>> ListByStock(int stockID, byte type)
        {
            return await _IStockProducts.ListByStock(stockID, type);
        }
        #endregion
    }
}
