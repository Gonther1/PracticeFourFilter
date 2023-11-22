using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPractice.Dtos;
using AutoMapper;
using Domain.Entities;

namespace ApiPractice.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Oficina, OficinaDto>()
            .ReverseMap();  
        }
    }
}