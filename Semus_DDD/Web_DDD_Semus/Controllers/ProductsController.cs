using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entities.Entity;
using ApplicationApp.Interfaces;
using Web_DDD_Semus.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Web_DDD_Semus.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        #region Var & Constructor
        private readonly IProductApp _iProductApp;
        private readonly IStockApp _iStockApp;
        private readonly IStockProductsApp _iStockProductApp;

        public ProductsController(IProductApp iProductApp, IStockApp iStockApp, IStockProductsApp iStockProductApp)
        {
            _iProductApp = iProductApp;
            _iStockApp = iStockApp;
            _iStockProductApp = iStockProductApp;
        }
        #endregion

        public async Task<IActionResult> Index(int stockID, byte type)
        {
            var stock = await _iStockApp.GetEntityById(stockID);
            var productList = await _iStockProductApp.ListByStock(stockID, type);

            ViewBag.Stock = new StockDataModel()
            {
                ID = stock.ID,
                Description = stock.Description
            };

            ViewBag.Type = type;
            return View(productList);
        }

        public async Task<ActionResult> Details(byte type, string searchString)
        {
            var productList = await _iProductApp.ListByType(type);

            ViewBag.Type = type;
            return View(productList);
        }

        public IActionResult Create(byte type)
        {
            var newProduct = new ProductViewModel
            {
                Type = type
            };
            return View(newProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newProduct = new Product
                {
                    Description = model.Description,
                    Type = model.Type,
                    Category = model.Category
                };

                await _iProductApp.Add(newProduct);

                var newStockProducts = new StockProducts
                {
                    ProductID = newProduct.ID
                };

                await _iStockProductApp.Add(newStockProducts);

                return RedirectToAction(nameof(Index),
                                        routeValues: new { stockID = 1, type = model.Type });
            }
            return View(model);
        }

        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _interfaceProductApp.GetEntityById((int)id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(product);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Type,Category,ID,Description")] Product product)
        //{
        //    if (id != product.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            await _interfaceProductApp.Update(product);
        //        }
        //        catch
        //        {
        //            throw;
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(product);
        //}

        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _interfaceProductApp.GetEntityById((int)id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var product = await _interfaceProductApp.GetEntityById((int)id);
        //    await _interfaceProductApp.Delete(product);
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
