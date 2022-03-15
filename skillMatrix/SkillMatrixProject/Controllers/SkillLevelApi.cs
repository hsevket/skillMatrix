
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using SkillMatrixProject.Repositories;
using SkillMatrixProject.Models;

namespace IO.Swagger.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class SkillLevelApiController : ControllerBase
    { 
        private IRepository<SkillLevel> skillLevelRepo { get; set; }
        public SkillLevelApiController(IRepository<SkillLevel> skillLevelRepo)
        {
            this.skillLevelRepo = skillLevelRepo;
        }
        /// <summary>
        /// Add a new skill level to the application
        /// </summary>
        /// <param name="body">SkillLevel object that needs to be added to the application</param>
        /// <response code="405">Invalid input</response>
        [HttpPost]
        [Route("/v2/skillLevel")]
        
        [SwaggerOperation("AddSkillLevel")]
        public virtual IActionResult AddSkillLevel([FromBody]SkillLevel body)
        { 
            var  skillLevel = skillLevelRepo.Add(body);
            skillLevelRepo.SaveChanges();
            return Ok(skillLevel);
        }

        /// <summary>
        /// Deletes an Skill level
        /// </summary>
        /// <param name="skillLevelId">ID of skill to return</param>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Pet not found</response>
        [HttpDelete]
        [Route("/v2/skillLevel/{skillLevelId}")]
      
        [SwaggerOperation("DeleteSkillLevel")]
        public virtual IActionResult DeleteSkillLevel([FromRoute][Required]string skillLevelId)
        {
            skillLevelRepo.Delete(skillLevelId);
            skillLevelRepo.SaveChanges();
            return Ok();

        }

        /// <summary>
        /// Fetch all the Skills
        /// </summary>
        /// <remarks>return all Skills</remarks>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid status value</response>
        [HttpGet]
        [Route("/v2/skillLevel")]
        
        [SwaggerOperation("GetAllSkillLevels")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<SkillLevel>), description: "successful operation")]
        public virtual IActionResult GetAllSkillLevels()
        { 
            var allSkillLevels = skillLevelRepo.GetAll();
            return Ok(allSkillLevels);  
        }

        /// <summary>
        /// Find Skill level by ID
        /// </summary>
        /// <remarks>Returns a single skill level</remarks>
        /// <param name="skillLevelId">ID of skill to return</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Employee not found</response>
        [HttpGet]
        [Route("/v2/skillLevel/{skillLevelId}")]
        
        [SwaggerOperation("GetSkillLevelById")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<SkillLevel>), description: "successful operation")]
        public virtual IActionResult GetSkillLevelById([FromRoute][Required]string skillLevelId)
        {
            var skillLevel = skillLevelRepo.GetById(skillLevelId);
            return Ok(skillLevel);
        }

        /// <summary>
        /// Update an existing skill level
        /// </summary>
        /// <param name="body">Skill level object that needs to be updated</param>
        /// <param name="skillLevelId">ID of skill to return</param>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Pet not found</response>
        /// <response code="405">Validation exception</response>
        [HttpPut]
        [Route("/v2/skillLevel")]
        
        [SwaggerOperation("UpdateSkillLevel")]
        public virtual IActionResult UpdateSkillLevel([FromBody]SkillLevel body)
        {
            var updatedSkillLevel = skillLevelRepo.Update(body);
            skillLevelRepo.SaveChanges();
            return Ok(updatedSkillLevel);
        }
    }
}
