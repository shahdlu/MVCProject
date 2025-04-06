using AutoMapper;
using Demo.BussinessLogic.DataTransferObjects.EmployeeDtos;
using Demo.BussinessLogic.Factories;
using Demo.BussinessLogic.Services.Interfaces;
using Demo.DataAccess.Models.DepartmentModel;
using Demo.DataAccess.Models.EmployeeModel;
using Demo.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BussinessLogic.Services.Classes
{
    public class EmployeeService(IEmployeeRepository _employeeRepository, IMapper _mapper) : IEmployeeService
    {
        public IEnumerable<EmployeeDto> GetAllEmployees(bool withTracking = false)
        {
            var employeeDto = _employeeRepository.GetAll(e => new EmployeeDto()
            {
                Id = e.Id,
                Name = e.Name,
                Salary = e.Salary
            });
            //Scr = Employee
            //Dest = EployeeDto
            //var employeeDto = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
            return employeeDto;
            //return employees.Select(e => e.ToEmployeeDto());
        }

        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if(employee is null) 
                return null;
            else
                return _mapper.Map<Employee, EmployeeDetailsDto>(employee);
        }

        public int AddEmployee(CreatedEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<CreatedEmployeeDto, Employee>(employeeDto);
            return _employeeRepository.Add(employee);
        }

        public int UpdateEmployee(UpdatedEmployeeDto employeeDto)
        {
            return _employeeRepository.Update(_mapper.Map<UpdatedEmployeeDto, Employee>(employeeDto));
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee is null) return false;
            else
            {
                employee.IsDeleted = true;
                return _employeeRepository.Update(employee) > 0 ? true : false;
            }
        }
    }
}
