using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entities.Entity;
using ApplicationApp.Interfaces;

namespace Web_DDD_Semus.Controllers
{
    public class StockController : Controller
    {
        private readonly IStockApp _stockApp;

        public StockController(IStockApp stockApp)
        {
            _stockApp = stockApp;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _stockApp.List());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _stockApp.GetEntityById((int)id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DateRegister,DateUpdate,ID,Description")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                await _stockApp.Add(stock);
                return RedirectToAction(nameof(Index));
            }
            return View(stock);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _stockApp.GetEntityById((int)id);
            if (stock == null)
            {
                return NotFound();
            }
            return View(stock);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DateRegister,DateUpdate,ID,Description")] Stock stock)
        {
            if (id != stock.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _stockApp.Update(stock);
                }
                catch
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(stock);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _stockApp.GetEntityById((int)id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stock = await _stockApp.GetEntityById((int)id);
            await _stockApp.Delete(stock);
            return RedirectToAction(nameof(Index));
        }
    }
}
