
using skillMatrix.WebAPI.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixProject.Repositories
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        private SkillMatrixDbContext db;
        public GenericRepository(SkillMatrixDbContext db)
        {
            this.db = db;
        }
        public  virtual T Add(T entity)
        {
             return  db.Set<T>().Add(entity).Entity;

        }

        public virtual void Delete(string id)
        {
            var entity = db.Set<T>().Find(id);
             db.Set<T>().Remove(entity);
            
        }


        public virtual T GetById(string id)
        {
            var entity = db.Set<T>().Find(id);
            
            if (entity == null)
            {
                throw new Exception("an error has been occurred");
            }
            return  entity;
        }


       
        public virtual IEnumerable<T> GetAll()
        {
            return db.Set<T>().ToList();
            
        }

        public virtual T Update(T entity)
        {
            return db.Set<T>().Update(entity).Entity;
        }
        public virtual void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
