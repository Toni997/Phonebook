using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MojiKontaktiAPI.Models
{
    public class BrojTelefona
    {
        public int BrojTelefonaID { get; set; }
        public int KontaktID { get; set; }
        public string PozivniBrojDrzave { get; set; }
        public string Broj { get; set; }
        public string Opis { get; set; }
        public bool Glavni { get; set; }

        public virtual Kontakt Kontakt { get; set; }
    }
}
