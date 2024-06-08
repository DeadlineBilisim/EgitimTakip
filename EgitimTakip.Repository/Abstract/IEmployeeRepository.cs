using EgitimTakip.Models;
using EgitimTakip.Repository.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Repository.Abstract
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        ICollection<Employee> GetAll(int companyId);
    }
}
