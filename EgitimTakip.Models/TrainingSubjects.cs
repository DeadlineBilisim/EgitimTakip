using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Models
{
    public class TrainingSubjects:BaseModel
    {
        public string Name {  get; set; }
        public string Code { get; set; }

    //    public virtual ICollection<Training> Trainings { get; set; }
    }
}
