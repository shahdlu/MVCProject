using Demo.BussinessLogic.DataTransferObjects;
using Demo.DataAccess.Models.DepartmentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BussinessLogic.Factories
{
    static class DepartmentFactory
    {
        public static DepartmentDto ToDepartmentDto (this Department d)
        {
            return new DepartmentDto()
            {
                Id = d.Id,
                Code = d.Code,
                Description = d.Description,
                Name = d.Name,
                DateOfCreation = DateOnly.FromDateTime(d.CreatedOn)
            };
        }
        public static DepartmentDetailsDto ToDepartmentDetalisDto (this Department department)
        {
            return new DepartmentDetailsDto()
            {
                Id = department.Id,
                Name = department.Name,
                CreatedOn = DateOnly.FromDateTime(department.CreatedOn)
            };
        }
        public static Department ToEntity(this CreatedDepartmentDto departmentDto)
        {
            return new Department()
            {
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                Description = departmentDto.Description,
                CreatedOn = departmentDto.DateOfCreation.ToDateTime(new TimeOnly())
            };
        }
        public static Department ToEntity(this UpdatedDepartmentDto departmentDto)
        {
            return new Department()
            {
                Id = departmentDto.Id,
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                CreatedOn = departmentDto.DateOfCreation.ToDateTime(new TimeOnly()),
                Description = departmentDto.Description
            };
        }
    }
}
