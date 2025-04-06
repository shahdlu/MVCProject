using AutoMapper;
using Demo.BussinessLogic.DataTransferObjects.EmployeeDtos;
using Demo.DataAccess.Models.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BussinessLogic.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.EmpGender, options => options.MapFrom(scr => scr.Gender))
                .ForMember(dest => dest.EmpType, options => options.MapFrom(scr => scr.EmployeeType))
                .ForMember(dest => dest.Department, options => options.MapFrom(scr => scr.Department != null ? scr.Department.Name : null));

            CreateMap<Employee, EmployeeDetailsDto>()
                .ForMember(dest => dest.Gender, options => options.MapFrom(scr => scr.Gender))
                .ForMember(dest => dest.EmployeeType, options => options.MapFrom(scr => scr.EmployeeType))
                .ForMember(dest => dest.HiringDate, options => options.MapFrom(scr => DateOnly.FromDateTime(scr.HiringDate)))
                .ForMember(dest => dest.Department, options => options.MapFrom(scr => scr.Department != null ? scr.Department.Name : null));

            CreateMap<CreatedEmployeeDto, Employee>()
                .ForMember(dest => dest.HiringDate, options => options.MapFrom(scr => scr.HiringDate.ToDateTime(TimeOnly.MinValue)));

            CreateMap<UpdatedEmployeeDto, Employee>()
                .ForMember(dest => dest.HiringDate, options => options.MapFrom(scr => scr.HiringDate.ToDateTime(TimeOnly.MinValue)));
        }
    }
}
