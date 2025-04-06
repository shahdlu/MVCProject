using Demo.BussinessLogic.DataTransferObjects;
using Demo.BussinessLogic.DataTransferObjects.DepartmentDtos;
using Demo.BussinessLogic.Services.Interfaces;
using Demo.Presentation.ViewModels.DepartmentViewModel;
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
        //[ValidateAntiForgeryToken]// Action Filter
        public IActionResult Create(DepartmenViewModel departmentViewModel)
        {
            if (ModelState.IsValid)//server side validation
            {
                try
                {
                    var departmentDto = new CreatedDepartmentDto()
                    {
                        Name = departmentViewModel.Name,
                        Code = departmentViewModel.Code,
                        DateOfCreation = departmentViewModel.DateOfcreation,
                        Description = departmentViewModel.Description
                    };
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
            return View(departmentViewModel);
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

        #region Edit Department

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _departmentServices.GetDepartmentById(id.Value);
            if (department == null) return NotFound();
            var ViewModel = new DepartmenViewModel()
            {
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                DateOfcreation =department.CreatedOn
            };
            return View(ViewModel);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute]int id, DepartmenViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var updatadedDepartment = new UpdatedDepartmentDto()
                    {
                        Id = id,
                        Code = viewModel.Code,
                        Name = viewModel.Name,
                        Description = viewModel.Description,
                        DateOfCreation = viewModel.DateOfcreation
                    };
                    int result = _departmentServices.updateDepartment(updatadedDepartment);
                    if (result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department is not Updated");
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
                        return View("ErrorView", ex);
                    }
                }
            }
            return View(viewModel);
        }

        #endregion

        #region Delete Department

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _departmentServices.GetDepartmentById(id.Value);
            if(department == null) return NotFound();
            return View(department);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if(id == 0) return BadRequest();
            try
            {
                bool deleted = _departmentServices.DeleteDepartment(id);
                if (deleted)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Department is not deleted");
                    return RedirectToAction(nameof(Delete), new { id });
                }
            }
            catch (Exception ex)
            {
                //log Exception
                if (_environment.IsDevelopment())
                {
                    //1.Development => log error to console and return same view with Error message
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //2.Deployment => log error in file | table in database and return error view
                    _logger.LogError(ex.Message);
                    return View("ErrorView", ex);
                }
            }
        }

        #endregion
    }
}
