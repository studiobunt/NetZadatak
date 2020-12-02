using AspNetCoreWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NetZadatak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetZadatak.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProizvodiContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ProizvodiContext>>()))
            {
                if (context.Proizvodi.Any())
                {
                    return;   
                }

                context.Proizvodi.AddRange(
                    new Proizvod
                    {
                        Naziv = "Naziv1",
                        Opis = "Opis1",
                        Kategorija = "Kategorija1",
                        Proizvodjac = "Proizvodjac1",
                        Dobavljac = "Dobavljac1",
                        Cena = 7.99
                    },

                    new Proizvod
                    {
                        Naziv = "Naziv2",
                        Opis = "Opis2",
                        Kategorija = "Kategorija2",
                        Proizvodjac = "Proizvodjac2",
                        Dobavljac = "Dobavljac2",
                        Cena = 2.99
                    },

                    new Proizvod
                    {
                        Naziv = "Naziv3",
                        Opis = "Opis3",
                        Kategorija = "Kategorija3",
                        Proizvodjac = "Proizvodjac3",
                        Dobavljac = "Dobavljac3",
                        Cena = 13.99
                    },

                    new Proizvod
                    {
                        Naziv = "Naziv4",
                        Opis = "Opis4",
                        Kategorija = "Kategorija4",
                        Proizvodjac = "Proizvodjac4",
                        Dobavljac = "Dobavljac4",
                        Cena = 33.99
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
