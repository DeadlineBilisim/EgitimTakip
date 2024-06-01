using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Models
{
    public class TrainingSubject:BaseModel
    {
        //

        public string Name {  get; set; }
        public string Code { get; set; }
        public int TrainingCategoryId {  get; set; }
        public virtual TrainingCategory TrainingCategory { get; set; }

        //    public virtual ICollection<Training> Trainings { get; set; }

        public virtual ICollection<TrainingsSubjectsMap> TrainingsSubjectsMap { get; set; } = new List<TrainingsSubjectsMap>();
    }
}
