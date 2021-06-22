using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MojiKontaktiAPI.Models;

namespace MojiKontaktiAPI.DTOs
{
    public class KontaktBazaDTO
    {
        [Required]
        [RegularExpression(@"^[a-žA-Ž]+$",
         ErrorMessage = "Only characters allowed.")]
        [MaxLength(50)]
        public string Ime { get; set; }
        [MaxLength(50)]
        public string Prezime { get; set; }
        [MaxLength(50)]
        public string Nadimak { get; set; }
        [MaxLength(300)]
        public string Adresa { get; set; }
        public bool Bookmarkiran { get; set; }
    }

    public class KontaktIzradaDTO : KontaktBazaDTO
    {
        public virtual IList<EmailAdresaIzradaDTO> EmailAdrese { get; set; }
        public virtual IList<BrojTelefonaIzradaDTO> BrojeviTelefona { get; set; }
        public virtual IList<TagIzradaDTO> Tagovi { get; set; }
    }

    public class KontaktIzmjenaDTO : KontaktBazaDTO
    {
        public virtual IList<EmailAdresaIzmjenaDTO> EmailAdrese { get; set; }
        public virtual IList<BrojTelefonaIzmjenaDTO> BrojeviTelefona { get; set; }
        public virtual IList<TagIzmjenaDTO> Tagovi { get; set; }
    }

    public class KontaktDTO : KontaktBazaDTO
    {
        public int KontaktID { get; set; }
        public virtual IList<EmailAdresaDTO> EmailAdrese { get; set; }
        public virtual IList<BrojTelefonaDTO> BrojeviTelefona { get; set; }
        public virtual IList<TagDTO> Tagovi { get; set; }
    }

}
