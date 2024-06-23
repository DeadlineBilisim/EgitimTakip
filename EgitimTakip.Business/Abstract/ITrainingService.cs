using EgitimTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Business.Abstract
{
    public interface ITrainingService
    {
        Training Add(Training training, List<TrainingsSubjectsMap> trainingsSubjectsMaps);
        Training Update(Training training, List<TrainingsSubjectsMap> trainingsSubjectsMaps);

        bool Delete(int traningId);

        ICollection<Training> GetAll(int companyId);

        Training UpdateAttendees(int trainingId, List<Employee> employees);
        Training GetById(int trainingId);
    }
}
