using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MojiKontaktiAPI.Models;

namespace MojiKontaktiAPI.DTOs
{
    public class TagIzradaDTO
    {
        public int KontaktID { get; set; }
        [Required]
        [MaxLength(20)]
        public string Naziv { get; set; }
    }

    public class TagDTO : TagIzradaDTO
    {
        public int TagID { get; set; }

        public virtual KontaktDTO Kontakt { get; set; }
    }
}
