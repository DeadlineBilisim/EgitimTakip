using EgitimTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Business.Abstract
{
    public interface ITrainingCategoryService
    {
        IQueryable<TrainingCategory> GetAll();
        TrainingCategory Add(TrainingCategory category);
        bool Delete(int categoryId);
        TrainingCategory Update(TrainingCategory category);

        TrainingCategory GetById(int categoryId);
    }
}
