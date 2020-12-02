using AspNetCoreWebApp.Models;
using Microsoft.EntityFrameworkCore;
using NetZadatak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetZadatak.Data.Repositories
{
    public class ProizvodRepository : IProizvodRepository
    {
        private readonly ProizvodiContext context;

        public ProizvodRepository(ProizvodiContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Proizvod proizvod)
        {
            await context.Proizvodi.AddAsync(proizvod);
        }

        public void Delete(Proizvod proizvod)
        {
            context.Proizvodi.Remove(proizvod);
        }

        public async Task<Proizvod> GetAsync(long id)
        {
            var proizvod = await context.Proizvodi.SingleOrDefaultAsync(u => u.Id == id);

            return proizvod;
        }

        public async Task<IEnumerable<Proizvod>> GetAsync()
        {
            return await context.Proizvodi.ToListAsync();
        }
        public Proizvod Update(Proizvod proizvod)
        {
            context.Proizvodi.Update(proizvod);
            return proizvod;
        }
    }
}
