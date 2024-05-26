using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Models
{
    public class AppUser:BaseModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Company> Companies { get; set; }=new List<Company>();

    }
}
