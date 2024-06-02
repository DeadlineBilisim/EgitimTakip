using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Models
{
    [Table("UserTypes")]
    public class AppUserType:BaseModel
    {
        public string Name {  get; set; }
        public virtual ICollection<AppUser> Users { get; set; }=new List<AppUser>();
    }
}
