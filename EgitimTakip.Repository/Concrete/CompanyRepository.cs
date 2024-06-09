using EgitimTakip.Data;
using EgitimTakip.IRepository.Shared.Concrete;
using EgitimTakip.Models;
using EgitimTakip.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Repository.Concrete
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _context;
        public CompanyRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
        public ICollection<Company> GetAll(int userId)
        {
          
          return  _context.Companies.Include(c=>c.Users).Where(c => c.Users.Any(u => u.Id == userId)).ToList();
        }

       
    }
}
