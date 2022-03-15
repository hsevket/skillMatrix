namespace SkillMatrixProject.DTOs
{
    public class SkillCategoryDto
    {
        public SkillCategoryDto(string name)
        {
            Name = name;
            this.Id = name;
        }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
