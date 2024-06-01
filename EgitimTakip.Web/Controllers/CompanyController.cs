using EgitimTakip.Data;
using EgitimTakip.Models;
using Microsoft.AspNetCore.Mvc;

namespace EgitimTakip.Web.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompanyController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            return Json(_context.Companies.Where(c=>!c.IsDeleted).ToList());
        }
        [HttpPost]
        public IActionResult Add(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
            return Ok(company);

        }
        [HttpPost]
        public IActionResult Update(Company company )
        {
           _context.Companies.Update(company);
            _context.SaveChanges();
            return Ok(company);
        }

        //[HttpPost]
        //public IActionResult Delete(int id)
        //{//HARD DELETE
        //    var company = _context.Companies.Find(id);
        //    _context.Companies.Remove(company);
        //    _context.SaveChanges();
        //    return Ok();


        //}
        [HttpPost]
        public IActionResult Delete(Company company)
        {
            //Hard Delete
            _context.Companies.Remove(company);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult SoftDelete(int id) 
        {


            //SOFT DELETE
            var company = _context.Companies.Find(id);
            company.IsDeleted = true;

            _context.Companies.Update(company);

            _context.SaveChanges();
            return Ok();
        
        }
    }
}
