using EgitimTakip.Data;
using EgitimTakip.Models;
using EgitimTakip.IRepository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;
using EgitimTakip.Business.Abstract;

namespace EgitimTakip.Web.Controllers
{
    public class TrainingCategoryController : Controller
    {
    private readonly ITrainingCategoryService _trainingCategoryService;

        public TrainingCategoryController(ITrainingCategoryService trainingCategoryService)
        {
            _trainingCategoryService = trainingCategoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            return Json(new { data = _trainingCategoryService.GetAll() });
        }
        [HttpPost]
        public IActionResult Add(TrainingCategory trainingCategory) 
        {
          
           TrainingCategory category= _trainingCategoryService.Add(trainingCategory);
            if(category.Id==0)
            {
                return BadRequest();
            }
            else
            {
                return Ok(category);
            }
       
        
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            return Ok(_trainingCategoryService.Delete(id) is object);
        }

        [HttpPost]
        public IActionResult Update(TrainingCategory trainingCategory)
        {
            return Ok(_trainingCategoryService.Update(trainingCategory));
        }
        [HttpPost]
        public IActionResult GetById(int id)
        {
            return Ok(_trainingCategoryService.GetById(id));
        }


        


       

    }
}
