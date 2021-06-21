using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MojiKontaktiAPI.Models
{
    public class EmailAdresa
    {
        public int EmailAdresaID { get; set; }
        public int KontaktID { get; set; }
        public string Email { get; set; }
        public bool Glavna { get; set; }

        public virtual Kontakt Kontakt { get; set; }

    }
}
