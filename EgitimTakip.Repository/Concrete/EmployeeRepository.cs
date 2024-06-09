using EgitimTakip.Data;
using EgitimTakip.Models;
using EgitimTakip.IRepository.Abstract;
using EgitimTakip.IRepository.Shared.Abstract;
using EgitimTakip.IRepository.Shared.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.IRepository.Concrete
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        

        public EmployeeRepository(ApplicationDbContext context):base(context)
        {
          
        }

        public ICollection<Employee> GetAll(int companyId)
        {
          return  base.GetAll().Where(emp => emp.CompanyId == companyId).ToList();

          //  return _context.Employees.Where(e=>!e.IsDeleted && e.CompanyId==companyId).ToList();
        }
    }
}
