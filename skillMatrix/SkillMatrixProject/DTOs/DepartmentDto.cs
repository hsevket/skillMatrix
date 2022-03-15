namespace SkillMatrixProject.DTOs
{
    public class DepartmentDto
    {
        public DepartmentDto(string name)
        {
            this.Name = name;
            this.Id = name;
        }
        
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
