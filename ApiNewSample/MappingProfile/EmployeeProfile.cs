using ApiNewSample.Dtos;
using ApiNewSample.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNewSample.MappingProfile
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(
                    dest => dest.Age,
                    opt =>
                    {
                        opt.MapFrom(src => Math.Ceiling(((DateTime.Now - src.DateOfBirth).TotalDays / 365.0)));
                    })
                .ForMember(
                    dest => dest.Name,
                    opt =>
                    {
                        opt.MapFrom(src => $"{src.FirstName} {src.LastName}");
                    })
                .ForMember(
                    dest => dest.GenderDisplay,
                    opt =>
                    {
                        opt.MapFrom(src => Enum.GetName(typeof(Gender), src.Gender));
                    }
                );

            CreateMap<EmployeeCreateDto, Employee>();

        }
    }
}
