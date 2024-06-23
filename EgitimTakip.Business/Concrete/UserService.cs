using EgitimTakip.Business.Abstract;
using EgitimTakip.IRepository.Shared.Abstract;
using EgitimTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IRepository<AppUser> _userRepository;

        public UserService(IRepository<AppUser> userRepository)
        {
            _userRepository = userRepository;
        }

        public AppUser Add(AppUser appUser)
        {
          return _userRepository.Add(appUser);
        }

        public AppUser CheckUser(string username, string password)
        {
            return _userRepository.GetFirstOrDefault(u => u.UserName == username && u.Password == password && !u.IsDeleted);
        }

        public bool Delete(int userId)
        {
           _userRepository.Delete(userId);
            return true;
        }

        public IQueryable<AppUser> GetAll()
        {
            return _userRepository.GetAll();
        }

        public AppUser Update(AppUser appUser)
        {
           return _userRepository.Update(appUser);
        }
    }
}
