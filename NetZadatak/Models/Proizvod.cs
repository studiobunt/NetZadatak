using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetZadatak.Models
{
    public class Proizvod
    {
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }
        public string Opis { get; set; }
        //public string Kategorija { get; set; }
        public string Proizvodjac { get; set; }
        public string Dobavljac { get; set; }
        [Required]
        public double Cena { get; set; }
        public Kategorija Kategorija { get; set; }
    }
}
