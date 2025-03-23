﻿using Demo.BussinessLogic.DataTransferObjects.DepartmentDtos;

namespace Demo.BussinessLogic.Services.Interfaces
{
    public interface IDepartmentService
    {
        int AddDepartment(CreatedDepartmentDto departmentDto);
        bool DeleteDepartment(int id);
        IEnumerable<DepartmentDto> GetAllDepartments();
        DepartmentDetailsDto? GetDepartmentById(int id);
        int updateDepartment(UpdatedDepartmentDto departmentDto);
    }
}