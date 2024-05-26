using EgitimTakip.Data;
using EgitimTakip.Models;
using Microsoft.AspNetCore.Mvc;

namespace EgitimTakip.Web.Controllers
{
    public class TrainingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrainingController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll(int companyId)
        {
            return Json(new { data = _context.Trainings.Where(t => t.CompanyId == companyId && !t.IsDeleted) });
        }
        [HttpPost]
        public IActionResult Add(Training training, List<TrainingsSubjectsMap> trainingsSubjectsMaps)
        {
            //ön yuzden, arka tarafa bir şekilde, her bir konunun Duration'ınını da göndermemiz gereiyor. Zaten elimizde, hem trainingID'yi hem SubjectId'yi hemde Duration'ı tutan zaten bir nesne var. Bu da TrainingsSubjectsMap nesnesi. Biz direkt ön yuzden arka yuze, bu nesne tipinde bir json olusturur gonderirsek, backend'deki işimiz aşırı kolaylaşmış olur.
            _context.Trainings.Add(training);
            _context.SaveChanges();

            foreach(var item in trainingsSubjectsMaps)
            {
                _context.TrainingsSubjectsMaps.Add(item);
            }
            _context.SaveChanges();
        
            return Ok(training);

        }

        [HttpPost]
        public IActionResult Update(Training training)
        {
            _context.Trainings.Update(training);
            _context.SaveChanges();
            return Ok(training);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
           Training training= _context.Trainings.Find(id);
            training.IsDeleted=true;
            _context.Trainings.Update(training);
            _context.SaveChanges();
            return Ok(training);
        }
    }
}
