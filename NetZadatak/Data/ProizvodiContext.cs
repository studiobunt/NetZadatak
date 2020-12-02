using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetZadatak.Models;

namespace AspNetCoreWebApp.Models
{
    public class ProizvodiContext : DbContext
    {
        public ProizvodiContext (DbContextOptions<ProizvodiContext> options)
            : base(options)
        {
        }

        public DbSet<Proizvod> Proizvodi { get; set; }
    }
}
