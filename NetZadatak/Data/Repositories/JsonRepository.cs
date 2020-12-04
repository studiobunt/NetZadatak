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
using Microsoft.Extensions.Configuration;

namespace NetZadatak.Data.Repositories
{
    public class JsonRepository : IJsonRepository
    {
        private object lockObj = new object();
        private readonly IConfiguration _configuration;

        public JsonRepository(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        List<Proizvod> IJsonRepository.GetProducts()
        {
            try
            {
                lock (this.lockObj) {
                var jsonFile = _configuration["jsonFile"];

                string Json = System.IO.File.ReadAllText(jsonFile);
                List<Proizvod> proizvodi = JsonConvert.DeserializeObject<List<Proizvod>>(Json);
                return proizvodi;
            }
            }
            catch (Exception)
            {
                return null;
            }
        }

        void IJsonRepository.AddProduct(Proizvod proizvod)
        {
            try
            {
                lock (this.lockObj)
                {
                    var jsonFile = _configuration["jsonFile"];

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
            }
            catch (Exception)
            {
                throw;

            }

        }

        public Proizvod GetProduct(int id)
        {
            try {
                lock (this.lockObj)
                {
                    var jsonFile = _configuration["jsonFile"];
                    string Json = System.IO.File.ReadAllText(jsonFile);
                    List<Proizvod> proizvodi = JsonConvert.DeserializeObject<List<Proizvod>>(Json);
                    Proizvod proizvod = proizvodi.Where(proizvod => proizvod.Id == id).SingleOrDefault();
                    return proizvod;
                }
        }
            catch (Exception)
            {
                throw;

            }
}

        public void UpdateProduct(Proizvod proizvod)
        {
            try {
                lock (this.lockObj)
                {
                    var jsonFile = _configuration["jsonFile"];

                    string Json = System.IO.File.ReadAllText(jsonFile);
                    List<Proizvod> proizvodi = JsonConvert.DeserializeObject<List<Proizvod>>(Json);
                    int index = proizvodi.FindIndex(pro => pro.Id == proizvod.Id);
                    proizvodi[index] = proizvod;
                    string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(proizvodi,
                               Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(jsonFile, newJsonResult);
                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        public void DeleteProduct(int id)
        {
            try
            {
                lock (this.lockObj)
                {
                    var jsonFile = _configuration["jsonFile"];

                    string Json = System.IO.File.ReadAllText(jsonFile);
                    List<Proizvod> proizvodi = JsonConvert.DeserializeObject<List<Proizvod>>(Json);
                    Proizvod proizvod = proizvodi.Where(proizvod => proizvod.Id == id).SingleOrDefault();
                    proizvodi.Remove(proizvod);
                    string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(proizvodi,
                   Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(jsonFile, newJsonResult);
                }
            }            
            catch (Exception)
            {
                throw;

            }
}
    }
}
