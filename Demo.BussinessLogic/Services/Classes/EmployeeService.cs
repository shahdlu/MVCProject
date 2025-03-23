using Demo.BussinessLogic.DataTransferObjects.EmployeeDtos;
using Demo.BussinessLogic.Factories;
using Demo.BussinessLogic.Services.Interfaces;
using Demo.DataAccess.Models.DepartmentModel;
using Demo.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BussinessLogic.Services.Classes
{
    public class EmployeeService(IEmployeeRepository _employeeRepository) : IEmployeeService
    {
        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAll();
            return employees.Select(e => e.ToEmployeeDto());
        }

        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if(employee is null) 
                return null;
            else
                return employee.ToEmployeeDetailsDto();
        }

        public int AddEmployee(CreatedEmployeeDto employeeDto)
        {
            var employee = employeeDto.ToEntity();
            return _employeeRepository.Add(employee);
        }

        public int UpdateEmployee(UpdatedEmployeeDto employeeDto)
        {
            return _employeeRepository.Update(employeeDto.ToEntity());
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee is null) return false;
            else
            {
                int result = _employeeRepository.Remove(employee);
                if (result > 0)
                    return true;
                else
                    return false;
            }
        }
    }
}
