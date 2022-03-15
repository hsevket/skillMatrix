
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillMatrixProject.Models
{
    public class Employee
    {
        
        public Employee(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;   
            Email = email; 
            this.LastUpdate = DateTime.Now.ToLongDateString();
            
        }
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string LastUpdate { get; set; }
        public bool IsDisabled { get; set; } = false;
        public bool IsAdmin { get; set; } = false;

        
        public string? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }
        public string? JobtitleId { get; set; }
        [ForeignKey("JobtitleId")]
        public virtual Jobtitle? Jobtitle { get; set; }
        
        public string? EmploymentStatusId { get; set; }
        [ForeignKey("EmploymentStatusId")]
        public EmploymentStatus? EmploymentStatus { get; set; }
        public string? ContractStatusId { get; set; }
        [ForeignKey("ContractStatusId")]
        public ContractStatus? ContractStatus { get; set; }
        public string? StartTime {get; set; }
        public string? EndTime { get; set; }
        public virtual IEnumerable<Employee_Skill>? Employee_Skills { get; set; }
       
    }
}
    