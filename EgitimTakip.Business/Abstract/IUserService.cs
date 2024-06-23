using EgitimTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Business.Abstract
{
    public interface IUserService
    {
        AppUser Add(AppUser appUser);
        AppUser Update(AppUser appUser);
        bool Delete(int userId);
        IQueryable<AppUser> GetAll();
        AppUser CheckUser(string username, string password);
    }
}
