using EgitimTakip.Data;
using EgitimTakip.Models;
using EgitimTakip.IRepository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EgitimTakip.Web.Controllers
{
    public class TrainingSubjectController : Controller
    {
        private readonly IRepository<TrainingSubject> _repo;

        public TrainingSubjectController(IRepository<TrainingSubject> repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {

            return Json(new { data = _repo.GetAll() });
        }
        [HttpPost]
        public IActionResult Add(TrainingSubject trainingSubject)
        {
     
            return Ok(_repo.Add(trainingSubject));

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
          
            return Ok(_repo.Delete(id) is object);
        }
        [HttpPost]
        public IActionResult Update(TrainingSubject trainingSubject)
        {
      
            return Ok(_repo.Update(trainingSubject));

        }
    }
}
