using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entities.Entity;
using ApplicationApp.Interfaces;

namespace Web_DDD_Semus.Controllers
{
    public class ProductsController : Controller
    {
        #region Var & Constructor
        private readonly IProductApp _interfaceProductApp;

        public ProductsController(IProductApp interfaceProductApp)
        {
            _interfaceProductApp = interfaceProductApp;
        }
        #endregion

        public async Task<IActionResult> Index(int stockID, byte type)
        {
            //var productList =  
            return View(await _interfaceProductApp.List());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _interfaceProductApp.GetEntityById((int)id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Type,Category,ID,Description")] Product product)
        {
            if (ModelState.IsValid)
            {
                await _interfaceProductApp.Add(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _interfaceProductApp.GetEntityById((int)id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Type,Category,ID,Description")] Product product)
        {
            if (id != product.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _interfaceProductApp.Update(product);
                }
                catch
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _interfaceProductApp.GetEntityById((int)id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _interfaceProductApp.GetEntityById((int)id);
            await _interfaceProductApp.Delete(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
