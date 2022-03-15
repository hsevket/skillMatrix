using System.ComponentModel.DataAnnotations;

namespace SkillMatrixProject.Models
{
    public class Jobtitle
    {
        public Jobtitle(string name)
        {
            this.Name = name;
            this.Id = name;
        }
        [Key]
        public string Id { get; set; } 
        public string Name { get; set; }
        public IEnumerable<Employee>? Employees { get; set; }
    }
}
