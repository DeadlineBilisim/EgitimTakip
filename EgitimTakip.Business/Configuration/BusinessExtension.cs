using EgitimTakip.Business.Abstract;
using EgitimTakip.Business.Concrete;
using EgitimTakip.IRepository.Shared.Abstract;
using EgitimTakip.IRepository.Shared.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Business.Configuration
{
    public static class BusinessExtension
    {
        public static void BusinessDI(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ITrainingService, TrainingService>();
            services.AddScoped<ITrainingCategoryService, TrainingCategoryService>();
        }
        public static void RepositoryDI(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
