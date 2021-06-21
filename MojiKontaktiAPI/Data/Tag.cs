using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MojiKontaktiAPI.Models
{
    public class Tag
    {
        public int TagID { get; set; }
        public int KontaktID { get; set; }
        public string Naziv { get; set; }
        
        public virtual Kontakt Kontakt { get; set; }

    }
}
