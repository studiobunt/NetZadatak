using NetZadatak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetZadatak.Data.Repositories
{
    public interface IJsonRepository
    {
        List<Proizvod> GetProducts();
        void AddProduct(Proizvod proizvod);
        void UpdateProduct(Proizvod proizvod);
        Proizvod GetProduct(int id);
        void DeleteProduct(int id);
    }
}
