using Microsoft.AspNetCore.Mvc;

namespace EgitimTakip.Web.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
