namespace SkillMatrixProject.DTOs
{
    public class JobtitleDto
    {
        public JobtitleDto(string name)
        {
            this.Name = name;
            this.Id = name;
        }
       
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
