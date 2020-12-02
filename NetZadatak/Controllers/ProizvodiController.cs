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
        private readonly ProizvodiContext _context;
        private readonly IProizvodRepository _proizvodRepo;

        public ProizvodiController(ProizvodiContext context, IProizvodRepository proizvodRepo)
        {
            _context = context;
            _proizvodRepo = proizvodRepo;

        }

        // GET: Proizvodi
        public async Task<IActionResult> Index()
        {
            return View(await _proizvodRepo.GetAsync());
        }


    }
}
