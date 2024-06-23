using EgitimTakip.Data;
using EgitimTakip.Models;
using Microsoft.AspNetCore.Mvc;
using EgitimTakip.Business.Abstract;

namespace EgitimTakip.Web.Controllers
{
    public class EmployeeController : Controller
    {
      private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetAll(int companyId)
        {
           
            return Json(new { data = _employeeService.GetAll(companyId) });
        }
        [HttpPost]
        public IActionResult Add(Employee employee)
        {
          
            return Ok(_employeeService.Add(employee));
        }

        [HttpPost]
        public IActionResult Update(Employee employee)
        {
           
            return Ok(_employeeService.Update(employee));
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
          
            return Ok(_employeeService.Delete(id));
        }

      

    }
}
