using EgitimTakip.Data;
using EgitimTakip.Models;
using Microsoft.AspNetCore.Mvc;

namespace EgitimTakip.Web.Controllers
{
    public class UserTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //single responsibility
            return View();
        }

        public IActionResult GetAll()
        {
            return Json(new {data=_context.UserTypes.Where(ut=>!ut.IsDeleted)});
            //JSON nesnesi geriye döndürüyor.
            //anonim obje oluşturup, veritabanına baglantı açıp kapatıypr. Ve bir de gelen verinin nasıl filtrelenmesi gerektiğine karar veriyor.
        }
        [HttpPost]
        public IActionResult Add(AppUserType userType)
        {
           _context.UserTypes.Add(userType);
            _context.SaveChanges();
            return Ok(userType);
        }

        public IActionResult Update(AppUserType userType)
        {
            _context.UserTypes.Update(userType);
            _context.SaveChanges();
            return Ok(userType);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var userType = _context.UserTypes.Find(id);
            userType.IsDeleted = true;
            _context.UserTypes.Update(userType);
            _context.SaveChanges();
            return Ok();

            //geriye OK mesajı gönderiyor
            //vveritabanına baglantı açıp kapatıyor.
            //gelen nesneyi editliyor, updateliyor, veritabanına KAYDEDİYOR

        }
        [HttpPost]
        public IActionResult GetById(int id)
        {
            return Ok(_context.UserTypes.Find(id));

            //geriye bir tane OK mesajı içerisinde obje  dönüyor.
            //_context'e baglanıyor ve bu vesileyle bir veri tabanı bağlantısı açıp kapatıyor.
        }
    }
}
