using NetZadatak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetZadatak.Data.Repositories
{
    public interface IProizvodRepository
    {
        Task<Proizvod> GetAsync(int id);
        Task<IEnumerable<Proizvod>> GetAsync();
        Task AddAsync(Proizvod proizvod);
        Proizvod Update(Proizvod proizvod);
        void Delete(Proizvod proizvod);
        void Save();

    }
}
