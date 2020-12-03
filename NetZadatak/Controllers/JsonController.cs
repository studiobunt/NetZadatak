using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetCoreWebApp.Models;
using NetZadatak.Models;
using NetZadatak.Data.Repositories;
using Newtonsoft.Json;

namespace NetZadatak.Controllers
{
    public class JsonController : Controller
    {
        private readonly IJsonRepository _jsonRepo;

        public JsonController(IJsonRepository jsonRepo)
        {
            _jsonRepo = jsonRepo;

        }

        public async Task<IActionResult> Index()
        {
            var proizvodi = _jsonRepo.GetProducts();
            return View(proizvodi);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Proizvod proizvod)
        {
            if (ModelState.IsValid)
            {
                 _jsonRepo.AddProduct(proizvod);
                return RedirectToAction(nameof(Index));
            }
            return View(proizvod);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var proizvod = _jsonRepo.GetProduct(id);
            if (proizvod == null)
            {
                return NotFound();
            }
            return View(proizvod);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Proizvod proizvod)
        {
            if (id != proizvod.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _jsonRepo.UpdateProduct(proizvod);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_jsonRepo.GetProduct(proizvod.Id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(proizvod);
        }

        public async Task<IActionResult> Delete(int id)
        {

            var proizvod = _jsonRepo.GetProduct(id);
            if (proizvod == null)
            {
                return NotFound();
            }

            return View(proizvod);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _jsonRepo.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
