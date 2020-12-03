using AspNetCoreWebApp.Models;
using Microsoft.EntityFrameworkCore;
using NetZadatak.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NetZadatak.Data.Repositories
{
    public class JsonRepository : IJsonRepository
    {
        private string jsonFile = @"D:\GITProjects\NetZadatak\NetZadatak\wwwroot\proizvodi.json";

        public JsonRepository()
        {
        }

        List<Proizvod> IJsonRepository.GetProducts()
        {
            try
            {
                string Json = System.IO.File.ReadAllText(jsonFile);
                List<Proizvod> proizvodi = JsonConvert.DeserializeObject<List<Proizvod>>(Json);
                return proizvodi;
            }
            catch (Exception)
            {
                throw;
            }
        }

        void IJsonRepository.AddProduct(Proizvod proizvod)
        {
            try
            {
                string Json = System.IO.File.ReadAllText(jsonFile);
                List<Proizvod> proizvodi = JsonConvert.DeserializeObject<List<Proizvod>>(Json);
                Proizvod poslednjiProizvod;
                if (proizvodi.Count != 0)
                {
                     poslednjiProizvod = proizvodi[proizvodi.Count - 1];
                     proizvod.Id = poslednjiProizvod.Id + 1;
                }
                else
                {
                    proizvod.Id = 1;
                }

                proizvodi.Add(proizvod);
                string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(proizvodi,
                                       Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(jsonFile, newJsonResult);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Proizvod GetProduct(int id)
        {
            string Json = System.IO.File.ReadAllText(jsonFile);
            List<Proizvod> proizvodi = JsonConvert.DeserializeObject<List<Proizvod>>(Json);
            Proizvod proizvod = proizvodi.Where(proizvod => proizvod.Id == id).SingleOrDefault();
            return proizvod;
        }

        public void UpdateProduct(Proizvod proizvod)
        {
            string Json = System.IO.File.ReadAllText(jsonFile);
            List<Proizvod> proizvodi = JsonConvert.DeserializeObject<List<Proizvod>>(Json);
            int index = proizvodi.FindIndex(pro => pro.Id == proizvod.Id);
            proizvodi[index] = proizvod;
            string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(proizvodi,
                       Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(jsonFile, newJsonResult);

        }

        public void DeleteProduct(int id)
        {
            string Json = System.IO.File.ReadAllText(jsonFile);
            List<Proizvod> proizvodi = JsonConvert.DeserializeObject<List<Proizvod>>(Json);
            Proizvod proizvod = proizvodi.Where(proizvod => proizvod.Id == id).SingleOrDefault();
            proizvodi.Remove(proizvod);
            string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(proizvodi,
           Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(jsonFile, newJsonResult);
        }
    }
}
