using Demo.BussinessLogic.DataTransferObjects.DepartmentDtos;
using Demo.BussinessLogic.Factories;
using Demo.BussinessLogic.Services.Interfaces;
using Demo.DataAccess.Models;
using Demo.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BussinessLogic.Services.Classes
{
    public class DepartmentService(IUnitOfWork _unitOfWork) : IDepartmentService
    {
        //get all departments
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            return departments.Select(d => d.ToDepartmentDto());
        }

        //get department by id
        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
            var departmrnt = _unitOfWork.DepartmentRepository.GetById(id);
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
            _unitOfWork.DepartmentRepository.Add(department);
            return _unitOfWork.SaveChange();
        }
        //updates Department
        public int updateDepartment(UpdatedDepartmentDto departmentDto)
        {
            _unitOfWork.DepartmentRepository.Update(departmentDto.ToEntity());
            return _unitOfWork.SaveChange();
        }
        //deleted department
        public bool DeleteDepartment(int id)
        {
            var dept = _unitOfWork.DepartmentRepository.GetById(id);
            if (dept is null) return false;
            else
            {
                _unitOfWork.DepartmentRepository.Remove(dept);
                int result = _unitOfWork.SaveChange();
                if (result > 0) return true;
                else
                    return false;
            }
        }
    }
}
