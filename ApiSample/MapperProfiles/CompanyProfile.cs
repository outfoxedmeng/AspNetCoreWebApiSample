using ApiSample.Dto;
using ApiSample.Entity;
using AutoMapper;
using AutoMapper.Configuration.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSample.MapperProfiles
{
    public class CompanyProfile : Profile
    {

        public CompanyProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ForMember(d => d.CompanyName, option => option.MapFrom(s => s.Name));
        }


    }
}
