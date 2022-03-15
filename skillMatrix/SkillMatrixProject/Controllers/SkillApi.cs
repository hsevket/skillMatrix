
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using SkillMatrixProject.Repositories;
using SkillMatrixProject.Models;
using AutoMapper;
using SkillMatrixProject.DTOs;

namespace skillMatrix.WebAPI.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class SkillApiController : ControllerBase
    { 
        private IRepository<Skill> skillRepo { get; set; }
        private IMapper mapper;
        public SkillApiController(IRepository<Skill> skillRepo, IMapper mapper)
        {
            this.skillRepo = skillRepo;
            this.mapper = mapper;
        }
        /// <summary>
        /// Add a new skill to the application
        /// </summary>
        /// <param name="body">Skill object that needs to be added to the application</param>
        /// <response code="405">Invalid input</response>
        [HttpPost]
        [Route("/v2/skill")]
     
        [SwaggerOperation("AddSkill")]
        public virtual IActionResult AddSkill([FromBody]SkillDto body)
        { 
            var addedSkill = mapper.Map<Skill>(body);
            var skill = skillRepo.Add(addedSkill);
            skillRepo.SaveChanges();
            return Ok(mapper.Map<SkillDto>(skill));
        }

        /// <summary>
        /// Deletes an employee
        /// </summary>
        /// <param name="skillId">ID of skill to return</param>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Pet not found</response>
        [HttpDelete]
        [Route("/v2/skill/{skillId}")]
        
        [SwaggerOperation("DeleteSkill")]
        public virtual IActionResult DeleteSkill([FromRoute][Required]string skillId)
        { 
            skillRepo.Delete(skillId);
            skillRepo.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Fetch all the Skills
        /// </summary>
        /// <remarks>return all Skills</remarks>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid status value</response>
        [HttpGet]
        [Route("/v2/skill")]
        
        [SwaggerOperation("GetAllSkills")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Skill>), description: "successful operation")]
        public virtual IActionResult GetAllSkills()
        { 
            var allSkills = skillRepo.GetAll();
            var result = new List<SkillDto>(); 
            foreach (var skill in allSkills)
            {
                result.Add(mapper.Map<SkillDto>(skill));
            }
            return Ok(result);
        }

        /// <summary>
        /// Find employee by ID
        /// </summary>
        /// <remarks>Returns a single employee</remarks>
        /// <param name="skillId">ID of skill to return</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Employee not found</response>
        [HttpGet]
        [Route("/v2/skill/{skillId}")]
        
        [SwaggerOperation("GetSkillById")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Skill>), description: "successful operation")]
        public virtual IActionResult GetSkillById([FromRoute][Required]string skillId)
        { 
            var skill = skillRepo.GetById(skillId);
            if (skill == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<SkillDto>(skill));
        }

        /// <summary>
        /// Update an existing skill
        /// </summary>
        /// <param name="body">Skill object that needs to be updated</param>
        /// <param name="skillId">ID of skill to return</param>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Pet not found</response>
        /// <response code="405">Validation exception</response>
        [HttpPut]
        [Route("/v2/skill/{skillId}")]
       
        [SwaggerOperation("UpdateSkill")]
        public virtual IActionResult UpdateSkill([FromBody]Skill body, [FromRoute][Required]Skill skill)
        {
            var updatedSkill = skillRepo.Update(skill);
            skillRepo.SaveChanges();
            return Ok(mapper.Map<SkillDto>(updatedSkill));
        }
    }
}
