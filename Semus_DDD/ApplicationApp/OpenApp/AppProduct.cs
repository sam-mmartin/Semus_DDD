using ApplicationApp.Interfaces;
using Domain.Interfaces.InterfaceEntities;
using Entities.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationApp.OpenApp
{
    public class AppProduct : IProductApp
    {
        private readonly IProduct _IProduct;

        public AppProduct(IProduct IProduct)
        {
            _IProduct = IProduct;
        }

        #region Methods
        public async Task Add(Product Object)
        {
            await _IProduct.Add(Object);
        }

        public async Task Delete(Product Object)
        {
            await _IProduct.Delete(Object);
        }

        public async Task<Product> GetEntityById(int Id)
        {
            return await _IProduct.GetEntityById(Id);
        }

        public async Task<List<Product>> List()
        {
            return await _IProduct.List();
        }

        public async Task Update(Product Object)
        {
            await _IProduct.Update(Object);
        }
        #endregion
    }
}
