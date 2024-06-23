using EgitimTakip.Data;
using EgitimTakip.Models;
using EgitimTakip.IRepository.Shared.Abstract;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using EgitimTakip.Business.Abstract;
using System.Security.Claims;

namespace EgitimTakip.Web.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public IActionResult Index()
        {
            return View();
        }
    

        public IActionResult GetAll()
        {
           return Json(_companyService.GetAll(int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)));
        }
        [HttpPost]
        public IActionResult Add(Company company)
        {

            return Ok(_companyService.Add(company));

        }
        [HttpPost]
        public IActionResult Update(Company company )
        {
           
            return Ok(_companyService.Update(company));
        }

    
        [HttpPost]
        public IActionResult SoftDelete(int id) 
        {
         _companyService.Delete(id);
            return Ok();
        
        }
    }
}
