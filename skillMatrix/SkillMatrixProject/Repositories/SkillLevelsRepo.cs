

using skillMatrix.WebAPI.Data.DataContext;
using SkillMatrixProject.Models;

namespace SkillMatrixProject.Repositories
{
    public class SkillLevelsRepo : GenericRepository<SkillLevel>
    {
       
        public SkillLevelsRepo(SkillMatrixDbContext db): base(db)
        {
           
        }
    }
}
