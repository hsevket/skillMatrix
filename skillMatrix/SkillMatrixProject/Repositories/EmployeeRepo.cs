
using skillMatrix.WebAPI.Data.DataContext;
using SkillMatrixProject.DTOs;
using SkillMatrixProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixProject.Repositories
{
    public class EmployeeRepo : GenericRepository<Employee>
    {
       

        public EmployeeRepo(SkillMatrixDbContext db):base(db)
        {
            
        }
        
    }
}
