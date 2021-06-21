using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MojiKontaktiAPI.Models
{
    public class Kontakt
    {
        public int KontaktID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Nadimak { get; set; }
        public string Adresa { get; set; }
        public bool Bookmarkiran { get; set; }

        public virtual IList<EmailAdresa> EmailAdrese { get; set; }
        public virtual IList<BrojTelefona> BrojeviTelefona { get; set; }
        public virtual IList<Tag> Tagovi { get; set; }
    }
}
