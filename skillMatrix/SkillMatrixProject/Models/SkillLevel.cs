using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixProject.Models
{
    public class SkillLevel
    {
      
        public SkillLevel(string name, int level)
        {
            Name = name;
            Level = level;
            this.Id = name;

        }
        
        public string Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        
    }
}
