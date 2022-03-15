namespace SkillMatrixProject.DTOs
{
    public class EmploymentStatusDto
    {
        public EmploymentStatusDto(string name)
        {
            this.Name = name;
            this.Id = name;
        }
       
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
