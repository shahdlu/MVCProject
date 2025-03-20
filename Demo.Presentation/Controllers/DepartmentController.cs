using Demo.BussinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class DepartmentController(IDepartmentService departmentServices) : Controller
    {
        public IActionResult Index()
        {
            var departments = departmentServices.GetAllDepartments();
            return View();
        }
    }
}
