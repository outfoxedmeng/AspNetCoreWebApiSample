using ApiNewSample.Dtos;
using ApiNewSample.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNewSample.MappingProfile
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ForMember(
                     d => d.CompanyName,
                     opt => opt.MapFrom(r => r.Name)
               );

            CreateMap<CompanyAddDto, Company>();
        }

    }
}
