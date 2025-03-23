using Demo.BussinessLogic.DataTransferObjects;
using Demo.BussinessLogic.Factories;
using Demo.DataAccess.Models;
using Demo.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BussinessLogic.Services
{
    public class DepartmentService(IDepartmentRepository _departmentRepository) : IDepartmentService
    {
        //get all departments
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _departmentRepository.GetAll();
            return departments.Select(d => d.ToDepartmentDto());
        }

        //get department by id
        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
            var departmrnt = _departmentRepository.GetById(id);
            if (departmrnt is null) return null;
            //munual mapping
            //auto mapper
            //constructor mapping
            //extension methods
            else
            {
                return departmrnt.ToDepartmentDetalisDto();
            }
        }
        //create new public
        public int AddDepartment(CreatedDepartmentDto departmentDto)
        {
            var department = departmentDto.ToEntity();
            return _departmentRepository.Add(department);
        }
        //updates Department
        public int updateDepartment(UpdatedDepartmentDto departmentDto)
        {
            return _departmentRepository.Update(departmentDto.ToEntity());
        }
        //deleted department
        public bool DeleteDepartment(int id)
        {
            var dept = _departmentRepository.GetById(id);
            if (dept is null) return false;
            else
            {
                int result = _departmentRepository.Remove(dept);
                if (result > 0) return true;
                else
                    return false;
            }
        }
    }
}
