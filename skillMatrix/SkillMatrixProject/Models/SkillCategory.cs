using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixProject.Models
{
    public class SkillCategory
    {
        public SkillCategory(string name)
        {
            Name = name;
            this.Id = name;
        }
        [Key]
        public string Id { get; set; } 
        public string Name { get; set; }
        public IEnumerable<Skill>? Skills { get; set; } 
    }
}
