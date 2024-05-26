using EgitimTakip.Data;
using EgitimTakip.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EgitimTakip.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AppUser user)
        {
            AppUser appUser = _context.Users.FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
            if ((appUser != null))
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString()));
                claims.Add(new Claim(ClaimTypes.GivenName, appUser.UserName));

                claims.Add(new Claim(ClaimTypes.Role, appUser.IsAdmin ? "Admin" : "User"));

                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(new ClaimsPrincipal(identity));


                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }


        }


        [HttpPost]
        public IActionResult Add(AppUser user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Update(AppUser user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            //SOFT DELETE
            AppUser user = _context.Users.Find(id);
            user.IsDeleted = true;
       
            _context.Users.Update(user);

            _context.SaveChanges();
            return Ok();

        }

        public IActionResult GetAll()
        {
            var result = _context.Users.Where(u => u.IsDeleted == false).ToList();

            return Json(new { data = result });

        }
    }
}
