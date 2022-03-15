
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillMatrixProject.Models
{
    public class Skill
    {
        public Skill(string name)
        {
                this.Name = name;
            this.Id = name;
        }
        
        public string Id { get; set; } 
        
        public SkillCategory? SkillCategory { get; set; }
        
        public string? SkillCategoryId  { get; set; }
        public string Name { get; set; }
        public IEnumerable<Employee_Skill> Employee_Skills { get; set; }
    }
}
