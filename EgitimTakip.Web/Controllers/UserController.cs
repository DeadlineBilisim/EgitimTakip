using EgitimTakip.Data;
using EgitimTakip.Models;
using EgitimTakip.IRepository.Shared.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

using EgitimTakip.Business.Abstract;

namespace EgitimTakip.Web.Controllers
{
    public class UserController : Controller
    {
       private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
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
            AppUser appUser = _userService.CheckUser(user.UserName,user.Password);
            
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
           
            return Ok(_userService.Add(user));
        }

        [HttpPost]
        public IActionResult Update(AppUser user)
        {
            return Ok(_userService.Update(user));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            return Ok(_userService.Delete(id));

        }

        public IActionResult GetAll()
        {
         

            return Json(new { data = _userService.GetAll() });

        }
    }
}
