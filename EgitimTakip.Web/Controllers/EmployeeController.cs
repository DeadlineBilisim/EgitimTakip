using EgitimTakip.Data;
using EgitimTakip.Models;
using EgitimTakip.IRepository.Abstract;
using EgitimTakip.IRepository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EgitimTakip.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeController(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetAll(int companyId)
        {
            //var result = _context.Employees.Where(e=>e.CompanyId==companyId && !e.IsDeleted).ToList();
            //return Json(new { data = result });
           return Json(new { data = _repo.GetAll(companyId) });
        }
        [HttpPost]
        public IActionResult Add(Employee employee)
        {
          
            return Ok(_repo.Add(employee));
        }

        [HttpPost]
        public IActionResult Update(Employee employee)
        {
           
            return Ok(_repo.Update(employee));
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
          
            return Ok(_repo.Delete(id) is object);
        }

      

    }
}
