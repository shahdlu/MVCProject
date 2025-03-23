using Demo.BussinessLogic.DataTransferObjects.EmployeeDtos;
using Demo.DataAccess.Models.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BussinessLogic.Factories
{
    public static class EmployeeFactory
    {
        public static EmployeeDto ToEmployeeDto(this Employee e)
        {
            return new EmployeeDto
            {
                Id = e.Id,
                Name = e.Name,
                Age = e.Age,
                IsActive = e.IsActive,
                Salary = e.Salary,
                Email = e.Email,
                Gender = e.Gender,
                EmployeeType = e.EmployeeType
            };
        }
        public static EmployeeDetailsDto ToEmployeeDetailsDto(this Employee e)
        {
            return new EmployeeDetailsDto
            {
                Id = e.Id,
                Name = e.Name,
                Age = e.Age,
                Address = e.Address,
                IsActive = e.IsActive,
                Salary = e.Salary,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                HiringDate = e.HiringDate,
                Gender = e.Gender,
                EmployeeType = e.EmployeeType
            };
        }
        public static Employee ToEntity(this CreatedEmployeeDto employeeDto)
        {
            return new Employee
            {
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                Address = employeeDto.Address,
                IsActive = employeeDto.IsActive,
                Salary = employeeDto.Salary,
                Email = employeeDto.Email,
                PhoneNumber = employeeDto.PhoneNumber,
                HiringDate = employeeDto.HiringDate,
                Gender = employeeDto.Gender,
                EmployeeType = employeeDto.EmployeeType,
                CreatedBy = employeeDto.CreatedBy,
                LastModifedBy = employeeDto.LastModifedBy
            };
        }
        public static Employee ToEntity(this UpdatedEmployeeDto employeeDto)
        {
            return new Employee
            {
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                Address = employeeDto.Address,
                IsActive = employeeDto.IsActive,
                Salary = employeeDto.Salary,
                Email = employeeDto.Email,
                PhoneNumber = employeeDto.PhoneNumber,
                HiringDate = employeeDto.HiringDate,
                Gender = employeeDto.Gender,
                EmployeeType = employeeDto.EmployeeType,
                CreatedBy = employeeDto.CreatedBy,
                LastModifedBy = employeeDto.LastModifedBy
            };
        }
    }
}
