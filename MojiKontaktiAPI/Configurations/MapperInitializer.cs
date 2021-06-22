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
                //.ForMember(d => d.Tagovi, opt => opt.Ignore())
                //.AfterMap(AddOrUpdateCities);
            CreateMap<EmailAdresaIzmjenaDTO, EmailAdresa>().ReverseMap();
            CreateMap<BrojTelefonaIzmjenaDTO, BrojTelefona>().ReverseMap();
            CreateMap<TagIzmjenaDTO, Tag>().ReverseMap();

            //private void AddOrUpdateCities(KontaktIzmjenaDTO dto, Kontakt kontakt)
            //{
            //    foreach (var tagDTO in dto.Tagovi)
            //    {
            //        if (tagDTO.TagID == 0)
            //        {
            //            kontakt.Tagovi.Add(Mapper.Map<Tag>(tagDTO));
            //        }
            //        else
            //        {
            //            Mapper.Map(tagDTO, kontakt.Tagovi.SingleOrDefault(c => c.KontaktID == tagDTO.TagID));
            //        }
            //    }
            //}
        }
    }
}
