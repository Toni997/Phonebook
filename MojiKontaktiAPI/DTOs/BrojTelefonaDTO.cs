using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MojiKontaktiAPI.Models;

namespace MojiKontaktiAPI.DTOs
{
    public class BrojTelefonaIzradaDTO
    {
        [Required]
        [MaxLength(3)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Only numbers allowed.")]
        public string PozivniBrojDrzave { get; set; }
        [Required]
        [MaxLength(10)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Only numbers allowed.")]
        public string Broj { get; set; }
        [MaxLength(30)]
        public string Opis { get; set; }
        public bool Glavni { get; set; }
    }

    public class BrojTelefonaIzmjenaDTO : BrojTelefonaIzradaDTO
    {

    }

    public class BrojTelefonaDTO : BrojTelefonaIzradaDTO
    {
        public int BrojTelefonaID { get; set; }

        public virtual KontaktDTO Kontakt { get; set; }
    }
}