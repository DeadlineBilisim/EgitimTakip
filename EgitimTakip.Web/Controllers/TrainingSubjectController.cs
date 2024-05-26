using EgitimTakip.Data;
using EgitimTakip.Models;
using Microsoft.AspNetCore.Mvc;

namespace EgitimTakip.Web.Controllers
{
    public class TrainingSubjectController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrainingSubjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            var result = _context.TrainingSubjects.ToList();
            return Json(new { data = result });
        }
        [HttpPost]
        public IActionResult Add(TrainingSubject trainingSubject)
        {
            _context.TrainingSubjects.Add(trainingSubject);
            _context.SaveChanges();
            return Ok(trainingSubject);

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            //SOFT DELETE
            TrainingSubject trainingSubject=_context.TrainingSubjects.Find(id);
            trainingSubject.IsDeleted = true;
            _context.TrainingSubjects.Update(trainingSubject);
            _context.SaveChanges();
            return Ok(trainingSubject);
        }
        [HttpPost]
        public IActionResult Update(TrainingSubject trainingSubject)
        {
            _context.TrainingSubjects.Update(trainingSubject);
            _context.SaveChanges();
            return Ok(trainingSubject);

        }
    }
}
