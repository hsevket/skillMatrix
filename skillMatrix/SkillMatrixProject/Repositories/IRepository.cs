using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixProject.Repositories
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        T Update(T entity);
        T GetById(string id);
        void Delete(string id);
        IEnumerable<T> GetAll();
        void SaveChanges();
       
    }
}
