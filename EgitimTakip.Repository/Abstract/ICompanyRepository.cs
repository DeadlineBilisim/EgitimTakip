using EgitimTakip.IRepository.Shared.Abstract;
using EgitimTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Repository.Abstract
{
    public interface ICompanyRepository:IRepository<Company>
    {
        ICollection<Company> GetAll(int userId);
    }
}
