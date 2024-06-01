using EgitimTakip.Data;
using Microsoft.AspNetCore.Mvc;

namespace EgitimTakip.Web.Controllers
{
    public class TrainingCategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrainingCategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            return Json(new { data = _context.TrainingCategories.Where(tc => !tc.IsDeleted).ToList() });
        }
    }
}
