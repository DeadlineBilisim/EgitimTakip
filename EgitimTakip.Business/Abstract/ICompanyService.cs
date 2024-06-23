using EgitimTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Business.Abstract
{
    public interface ICompanyService
    {
        IQueryable<Company> GetAll(int userId);
        Company Add(Company company);
        Company Update(Company company);
        bool Delete(int id);
    }
}
