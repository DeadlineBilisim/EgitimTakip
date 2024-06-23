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
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee Add(Employee employee)
        {
        return _employeeRepository.Add(employee);
        }

        public bool Delete(int employeeId)
        {
           _employeeRepository.Delete(employeeId);
            return true;
        }

        public IQueryable<Employee> GetAll(int companyId)
        {
            return _employeeRepository.GetAll(emp => emp.CompanyId == companyId);
        }

        public Employee Update(Employee employee)
        {
          return _employeeRepository.Update(employee);
        }
    }
}
