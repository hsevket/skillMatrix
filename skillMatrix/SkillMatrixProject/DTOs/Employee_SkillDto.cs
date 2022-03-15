namespace SkillMatrixProject.DTOs
{
    public class Employee_SkillDto
    {
        public Employee_SkillDto(string employeeId, string skillId)
        {
            EmployeeId = employeeId;
            SkillId = skillId;
        }

        
        public string EmployeeId { get; set; }
        public string SkillId { get; set; }
        public string? SkillLevelId { get; set; }
    }
}
