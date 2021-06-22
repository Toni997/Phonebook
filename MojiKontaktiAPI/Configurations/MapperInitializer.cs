using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MojiKontaktiAPI.DTOs;
using MojiKontaktiAPI.Models;

namespace MojiKontaktiAPI.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Kontakt, KontaktDTO>().ReverseMap();
            CreateMap<EmailAdresa, EmailAdresaDTO>().ReverseMap();
            CreateMap<BrojTelefona, BrojTelefonaDTO>().ReverseMap();
            CreateMap<Tag, TagDTO>().ReverseMap();

            CreateMap<KontaktIzradaDTO, Kontakt>().ReverseMap();
            CreateMap<EmailAdresaIzradaDTO, EmailAdresa>().ReverseMap();
            CreateMap<BrojTelefonaIzradaDTO, BrojTelefona>().ReverseMap();
            CreateMap<TagIzradaDTO, Tag>().ReverseMap();

            CreateMap<KontaktIzmjenaDTO, Kontakt>().ReverseMap();
            CreateMap<EmailAdresaIzmjenaDTO, EmailAdresa>().ReverseMap();
            CreateMap<BrojTelefonaIzmjenaDTO, BrojTelefona>().ReverseMap();
            CreateMap<TagIzmjenaDTO, Tag>().ReverseMap();

        }
    }
}
