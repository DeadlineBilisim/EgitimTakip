using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Models
{
    public class TrainingCategory:BaseModel
    {
        public string Name { get; set; }
        public virtual ICollection<TrainingSubject> Subjects { get; set; }
    }
}
