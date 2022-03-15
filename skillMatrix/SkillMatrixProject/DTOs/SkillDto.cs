using SkillMatrixProject.Models;

namespace SkillMatrixProject.DTOs
{
    public class SkillDto
    {
        public SkillDto(string name)
        {
            this.Name = name;
            this.Id = name;
        }

        public string Id { get; set; }

        public string? SkillCategoryId { get; set; }
        public string Name { get; set; }
        public SkillLevel? SkillLevel { get; set; }
    }
}
