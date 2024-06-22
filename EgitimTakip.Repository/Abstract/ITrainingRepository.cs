using EgitimTakip.Models;
using EgitimTakip.IRepository.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.IRepository.Abstract
{
    public interface ITrainingRepository:IRepository<Training>
    {
        ICollection<Training> GetAll(int companyId);
        Training Add(Training training, List<TrainingsSubjectsMap> trainingsSubjectsMaps);
        void UpdateAttendees(int trainingId, List<Employee> employees);
        void RemoveEmployee(int trainingId,Employee employee);

    }
}
