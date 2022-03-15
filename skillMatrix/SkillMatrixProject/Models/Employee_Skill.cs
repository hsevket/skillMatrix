using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SkillMatrixProject.Models
{
    public class Employee_Skill
    {
        public Employee_Skill(string employeeId, string skillId)
        {
            EmployeeId = employeeId;
            SkillId = skillId;
        }
        
        public Employee Employee { get; set; }
        [Required]
        [Key]
        public string EmployeeId { get; set; }
        public Skill Skill { get; set; }
        [Required]
        [Key]
        public string SkillId { get; set; }
        public SkillLevel? SkillLevel { get; set; }
        public string? SkillLevelId { get; set; }
    }
}
