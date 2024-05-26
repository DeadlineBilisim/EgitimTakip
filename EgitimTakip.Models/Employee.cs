using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Models
{
    public class Employee:BaseModel
    {
        public string FullName { get; set; }
        public string TCK { get; set; }
        public int CompanyId {  get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<Training> Trainings { get; set; }=new List<Training>();

    }
}
