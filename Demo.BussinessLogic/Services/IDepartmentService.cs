using Demo.BussinessLogic.DataTransferObjects;

namespace Demo.BussinessLogic.Services
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