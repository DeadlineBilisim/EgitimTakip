using EgitimTakip.IRepository.Shared.Abstract;
using EgitimTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.IRepository.Abstract
{
    public interface IUserRepository:IRepository<AppUser>
    {
        AppUser CheckUser(string username,string password);
    }
}
