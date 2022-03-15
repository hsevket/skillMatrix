using skillMatrix.WebAPI.Data.DataContext;
using SkillMatrixProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixProject.Repositories
{
    public class DepartmentRepo : GenericRepository<Department>
    {
        public DepartmentRepo(SkillMatrixDbContext db) : base(db)
        {

        }
    }
}
