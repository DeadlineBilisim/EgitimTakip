using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Models
{
    [Table("Users")]
    public class AppUser:BaseModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool IsAdmin { get; set; } = false;

        public virtual ICollection<Company> Companies { get; set; }=new List<Company>();

    }
}
