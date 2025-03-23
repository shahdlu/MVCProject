using Demo.BussinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class DepartmentController(IDepartmentService _departmentServices) : Controller
    {
        // GET BaseUrl/Department/Index
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentServices.GetAllDepartments();
            return View(departments);
        }
    }
}
