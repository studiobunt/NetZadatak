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

namespace NetZadatak.Controllers
{
    public class ProizvodiController : Controller
    {
        private readonly IProizvodRepository _proizvodRepo;

        public ProizvodiController(IProizvodRepository proizvodRepo)
        {
            _proizvodRepo = proizvodRepo;

        }

        public async Task<IActionResult> Index()
        {
            return View(await _proizvodRepo.GetAsync());
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
                await _proizvodRepo.AddAsync(proizvod);
                _proizvodRepo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(proizvod);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var proizvod = await _proizvodRepo.GetAsync(id);
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
                    _proizvodRepo.Update(proizvod);
                    _proizvodRepo.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_proizvodRepo.GetAsync(proizvod.Id)==null)
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

            var proizvod = await _proizvodRepo.GetAsync(id);
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
            var proizvod = await _proizvodRepo.GetAsync(id);
            _proizvodRepo.Delete(proizvod);
            _proizvodRepo.Save();
            return RedirectToAction(nameof(Index));
        }

    }
}
