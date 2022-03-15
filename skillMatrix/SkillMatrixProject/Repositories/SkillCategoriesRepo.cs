
using skillMatrix.WebAPI.Data.DataContext;
using SkillMatrixProject.Models;

namespace SkillMatrixProject.Repositories
{
    public class SkillCategoriesRepo : GenericRepository<SkillCategory>
    {
       
        public SkillCategoriesRepo(SkillMatrixDbContext db): base(db)
        {
            
        }
    }
}
