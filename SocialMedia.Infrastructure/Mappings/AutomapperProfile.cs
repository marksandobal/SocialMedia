using AutoMapper;
using SocialMedia.Core.Data;
using SocialMedia.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {// Configuracion del automapper
        public AutomapperProfile()
        {// Se crean los mapeos de las entidades con los DTOs y viceversa, es decir los DTOs con las Entidades
         // por ejemplo, si se realiza un request tipo POST, este debe mapear de Dto o Entity,
         // si es un request tipo GET, es un Entity a Dto
            CreateMap<Posts, PostsDto>();
            CreateMap<PostsDto, Posts>();
        }
    }
}
