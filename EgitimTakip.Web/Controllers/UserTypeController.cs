using EgitimTakip.Data;
using EgitimTakip.IRepository.Shared.Abstract;
using EgitimTakip.Models;
using Microsoft.AspNetCore.Mvc;

namespace EgitimTakip.Web.Controllers
{
    public class UserTypeController : Controller
    {
        private readonly IRepository<AppUserType> _repo;

        public UserTypeController(IRepository<AppUserType> repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            //single responsibility
            return View();
        }

        public IActionResult GetAll()
        {
            return Json(new {data=_repo.GetAll()});
            //JSON nesnesi geriye döndürüyor.
            //anonim obje oluşturup, veritabanına baglantı açıp kapatıypr. Ve bir de gelen verinin nasıl filtrelenmesi gerektiğine karar veriyor.
        }
        [HttpPost]
        public IActionResult Add(AppUserType userType)
        {
          
            return Ok(_repo.Add(userType));
        }

        public IActionResult Update(AppUserType userType)
        {
         
            return Ok(_repo.Update(userType));
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
          
            return Ok(_repo.Delete(id) is object);

            //geriye OK mesajı gönderiyor
            //vveritabanına baglantı açıp kapatıyor.
            //gelen nesneyi editliyor, updateliyor, veritabanına KAYDEDİYOR

        }
        [HttpPost]
        public IActionResult GetById(int id)
        {
            return Ok(_repo.GetById(id));

            //geriye bir tane OK mesajı içerisinde obje  dönüyor.
            //_context'e baglanıyor ve bu vesileyle bir veri tabanı bağlantısı açıp kapatıyor.
        }
    }
}
