using SkillMatrixProject.Models;

namespace SkillMatrixProject.DTOs
{
    public class EmployeeDto
    {
        public EmployeeDto()
        {
            this.LastUpdate = DateTime.Now.ToLongDateString();

        }
        public string? Id { get; set; } 
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string LastUpdate { get; set; }
        public bool IsDisabled { get; set; } = false;
        public bool IsAdmin { get; set; } = false;

        public string? DepartmentId { get; set; }

        public string? JobtitleId { get; set; }

        public string? EmploymentStatusId { get; set; }

        public string? ContractStatusId { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public List<SkillDto> Skills { get; set; } = new List<SkillDto>();

    }
}

