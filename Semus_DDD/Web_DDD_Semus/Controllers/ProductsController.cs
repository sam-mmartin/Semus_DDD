using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities.Entity;
using Infrastructure.Configuration;
using ApplicationApp.Interfaces;

namespace Web_DDD_Semus.Controllers
{
    public class ProductsController : Controller
    {
        private readonly InterfaceProductApp _interfaceProductApp;

        public ProductsController(InterfaceProductApp interfaceProductApp)
        {
            _interfaceProductApp = interfaceProductApp;
        }

        public async Task<IActionResult> Index()
        {
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
