using EgitimTakip.Business.Abstract;
using EgitimTakip.IRepository.Shared.Abstract;
using EgitimTakip.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Business.Concrete
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> _repo;

        public CompanyService(IRepository<Company> repo)
        {
            _repo = repo;
        }

        public Company Add(Company company)
        {
            return _repo.Add(company);
        }

        public bool Delete(int id)
        {
            _repo.Delete(id);
            return true;
        }

        public IQueryable<Company> GetAll(int userId)
        {
            return _repo.GetAll(c => c.Users.Any(u => u.Id == userId)).Include(c => c.Users);
        }

        public Company Update(Company company)
        {
            return _repo.Update(company);
        }
        
    }
}
