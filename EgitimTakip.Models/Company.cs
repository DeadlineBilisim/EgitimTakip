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
        public int AppUserId { get; set; }
        public virtual AppUser User { get; set; }   
        public virtual ICollection<Employee> Employees { get; set; }=new List<Employee>();

    }
}
