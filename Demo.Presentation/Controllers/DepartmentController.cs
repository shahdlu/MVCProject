using Demo.BussinessLogic.DataTransferObjects;
using Demo.BussinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class DepartmentController(IDepartmentService _departmentServices, ILogger<DepartmentController> _logger, IWebHostEnvironment _environment) : Controller
    {
        // GET BaseUrl/Department/Index
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentServices.GetAllDepartments();
            return View(departments);
        }

        #region Create Department

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatedDepartmentDto departmentDto)
        {
            if (ModelState.IsValid)//server side validation
            {
                try
                {
                    int result = _departmentServices.AddDepartment(departmentDto);
                    if (result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department can't be created");
                    }
                }
                catch (Exception ex)
                {
                    //log Exception
                    if (_environment.IsDevelopment())
                    {
                        //1.Development => log error to console and return same view with Error message
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else
                    {
                        //2.Deployment => log error in file | table in database and return error view
                        _logger.LogError(ex.Message);
                    }
                }
            }
            return View(departmentDto);
        }

        #endregion

        #region Details of Department

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _departmentServices.GetDepartmentById(id.Value);
            if (department == null) return NotFound();
            return View(department);
        }

        #endregion

    }
}
