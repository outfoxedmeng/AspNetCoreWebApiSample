using ApiSample.Dto;
using ApiSample.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSample.MapperProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(d => d.FullName, options => options.MapFrom(s => s.Name))
                .ForMember(d => d.Gender, options => options.MapFrom(s => s.Gender.ToString()));
        }

    }
}
