using AutoMapper;
using DOMAIN.Dtos;
using DOMAIN.Entities;
using Microsoft.Build.Experimental.ProjectCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Helper.Configs
{
    public class PerfilMapper : Profile
    {
        public PerfilMapper()
        {
            CreateMap<Tikect,TikectPost>().ReverseMap();
            CreateMap<Tikect,TikectPut>().ReverseMap();
            CreateMap<Historial, HistorialPut>().ReverseMap();
        }
    }
}
