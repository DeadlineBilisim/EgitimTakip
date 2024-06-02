using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Models
{
    public class Company:BaseModel
    {
        public string Name {  get; set; }
       
        public virtual ICollection<AppUser> Users { get; set; }   
        public virtual ICollection<Employee> Employees { get; set; }=new List<Employee>();
       // public virtual ICollection<Submission> Submissions { get; set; } = new List<Submission>();

   

    }
}
