using EgitimTakip.Data;
using EgitimTakip.IRepository.Abstract;
using EgitimTakip.IRepository.Shared.Concrete;
using EgitimTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.IRepository.Concrete
{
    public class UserRepository : Repository<AppUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context):base(context)
        {
            
        }
        public AppUser CheckUser(string username, string password)
        {
           //_context.Users.FirstOrDefault(u=>u.Username==username &&....)
          return base.GetFirstOrDefault(u=>u.UserName == username && u.Password == password && !u.IsDeleted);
        }
    }
}
