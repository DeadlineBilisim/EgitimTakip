using EgitimTakip.Data;
using EgitimTakip.Models;
using EgitimTakip.IRepository.Abstract;
using EgitimTakip.IRepository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EgitimTakip.Web.Controllers
{
    public class TrainingController : Controller
    {
        private readonly ITrainingRepository _repo;
        private readonly IRepository<TrainingsSubjectsMap> _subjectsRepo;

        public TrainingController(ITrainingRepository repo, IRepository<TrainingsSubjectsMap> subjectsRepo)
        {
            _repo = repo;
            _subjectsRepo = subjectsRepo;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll(int companyId)
        {
            return Json(new { data = _repo.GetAll(companyId) });
        }
        [HttpPost]
        public IActionResult Add(Training training, List<TrainingsSubjectsMap> trainingsSubjectsMaps)
        {
            //ön yuzden, arka tarafa bir şekilde, her bir konunun Duration'ınını da göndermemiz gereiyor. Zaten elimizde, hem trainingID'yi hem SubjectId'yi hemde Duration'ı tutan zaten bir nesne var. Bu da TrainingsSubjectsMap nesnesi. Biz direkt ön yuzden arka yuze, bu nesne tipinde bir json olusturur gonderirsek, backend'deki işimiz aşırı kolaylaşmış olur.
       
            return Ok(_repo.Add(training,trainingsSubjectsMaps));

        }

        [HttpPost]
        public IActionResult Update(Training training, List<TrainingsSubjectsMap> trainingsSubjectsMaps)
        {
            training.TrainingsSubjectsMap=new List<TrainingsSubjectsMap>();
            _repo.Update(training);

          
            

            training.TrainingsSubjectsMap = trainingsSubjectsMaps;
            return Ok(_repo.Update(training));
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            return Ok(_repo.Delete(id) is object);
        }
        [HttpPost]
        public IActionResult UpdateAttendees(int trainingId,List<Employee> attendees) {

            return Ok(_repo.UpdateAttendees(trainingId, attendees) is object);
        



        }
    }
}
