using EgitimTakip.Data;
using EgitimTakip.Models;
using EgitimTakip.Repository.Shared.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Repository.Shared.Concrete
{
    public class Repository<T> : IRepository<T> where T : BaseModel

        //Repository<Employee>
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;


        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet=_context.Set<T>();
        }

        public T Add(T entity)
        {

         //   _context.Set<T>().Add(entity);
         _dbSet.Add(entity);
            Save();
            return entity;

        }

        public List<T> AddRange(List<T> entities)
        {
           _dbSet.AddRange(entities);
            Save();
            return entities;
        }

        //SOFT DELETE
        public void Delete(int id)
        {
           T entity= _dbSet.Find(id);
            entity.IsDeleted = true;
            
            _dbSet.Update(entity);
            Save();
        }

        public ICollection<T> GetAll()
        {
            return _dbSet.Where(x => !x.IsDeleted).ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public void Save()
        {
           _context.SaveChanges();
        }

        public T Update(T entity)
        {
            _dbSet.Update(entity);
            Save();
            return entity;
        }
    }
}
