using EgitimTakip.Models;
using EgitimTakip.IRepository.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.IRepository.Abstract
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        ICollection<Employee> GetAll(int companyId);
    }
}
