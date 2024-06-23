using EgitimTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Business.Abstract
{
    public interface IEmployeeService
    {
        IQueryable<Employee> GetAll(int companyId);
        Employee Add(Employee employee);
        Employee Update(Employee employee);
        bool Delete(int employeeId);
    }
}
