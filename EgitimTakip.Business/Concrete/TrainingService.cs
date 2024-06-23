using EgitimTakip.Business.Abstract;
using EgitimTakip.IRepository.Shared.Abstract;
using EgitimTakip.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Business.Concrete
{
    public class TrainingService : ITrainingService
    {
        private readonly IRepository<Training> _trainingRepository;

        public TrainingService(IRepository<Training> trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }

        public Training Add(Training training, List<TrainingsSubjectsMap> trainingsSubjectsMaps)
        {
            _trainingRepository.Add(training);
            foreach (var item in trainingsSubjectsMaps)
            {
                item.TrainingId = training.Id;
                //  _context.TrainingsSubjectsMaps.Add(item);
            }

            training.TrainingsSubjectsMap = trainingsSubjectsMaps;
            _trainingRepository.Update(training);

            return training;
        }

        public bool Delete(int traningId)
        {
           _trainingRepository.Delete(traningId);
            return true;
        }

        public ICollection<Training> GetAll(int companyId)
        {
            return _trainingRepository.GetAll(t => t.CompanyId == companyId).ToList();
        }

        public Training GetById(int trainingId)
        {
            return _trainingRepository.GetAll(t => t.Id == trainingId).Include(t => t.Employees).First();
        }

      

        public Training Update(Training training, List<TrainingsSubjectsMap> trainingsSubjectsMaps)
        {
            training.TrainingsSubjectsMap = new List<TrainingsSubjectsMap>();
            _trainingRepository.Update(training);

            training.TrainingsSubjectsMap = trainingsSubjectsMaps;
            return _trainingRepository.Update(training);
        }

        public Training UpdateAttendees(int trainingId, List<Employee> employees)
        {
            Training training = _trainingRepository.GetById(trainingId);
            training.Employees = employees;
          return  _trainingRepository.Update(training);
            
        }
    }
}
