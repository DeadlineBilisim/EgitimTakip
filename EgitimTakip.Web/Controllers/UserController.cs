using EgitimTakip.Data;
using EgitimTakip.Models;
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
            if ((appUser!=null))
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier,appUser.Id.ToString()));
                claims.Add(new Claim(ClaimTypes.GivenName, appUser.UserName));

                claims.Add(new Claim(ClaimTypes.Role, appUser.IsAdmin ? "Admin" : "User"));
                
            }

            return Ok();
        }
    }
}
