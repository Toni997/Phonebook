using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MojiKontaktiAPI.Models;

namespace MojiKontaktiAPI.DTOs
{
    public class EmailAdresaIzradaDTO
    {
        //public int KontaktID { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(320)]
        public string Email { get; set; }
        public bool Glavna { get; set; }
    }

    public class EmailAdresaIzmjenaDTO : EmailAdresaIzradaDTO
    {

    }

    public class EmailAdresaDTO : EmailAdresaIzradaDTO
    {
        public int EmailAdresaID { get; set; }

        public virtual KontaktDTO Kontakt { get; set; }
    }
}
