using EgitimTakip.Data;
using EgitimTakip.Models;
using EgitimTakip.IRepository.Shared.Abstract;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EgitimTakip.Web.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IRepository<Company> _repo;

        public CompanyController(IRepository<Company> repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
           return Json(_repo.GetAll());
        }
        [HttpPost]
        public IActionResult Add(Company company)
        {
            //_context.Companies.Add(company);
            //_context.SaveChanges();
            //return Ok(company);

            return Ok(_repo.Add(company));

        }
        [HttpPost]
        public IActionResult Update(Company company )
        {
            //_context.Companies.Update(company);
            // _context.SaveChanges();
            // return Ok(company);
            return Ok(_repo.Update(company));
        }

    
        [HttpPost]
        public IActionResult SoftDelete(int id) 
        {


            //SOFT DELETE
            //var company = _context.Companies.Find(id);
            //company.IsDeleted = true;

            //_context.Companies.Update(company);

            //_context.SaveChanges();
            //return Ok();
         //   return Ok(_repo.Delete(id) is object);
         _repo.Delete(id);
            return Ok();
        
        }
    }
}
