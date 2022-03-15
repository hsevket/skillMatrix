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
    public class SkillCategoryApiController : ControllerBase
    { 
        private IRepository<SkillCategory> skillCategoryRepo { get; set; }
        private IMapper mapper;
        public SkillCategoryApiController(IRepository<SkillCategory> skillCategoryRepo, IMapper mapper)
        {
            this.skillCategoryRepo = skillCategoryRepo;
            this.mapper = mapper;
        }
        /// <summary>
        /// Add a new skill category to the application
        /// </summary>
        /// <param name="body">Skill Category object that needs to be added to the application</param>
        /// <response code="405">Invalid input</response>
        [HttpPost]
        [Route("/v2/skillCategory")]
      
        [SwaggerOperation("AddSkillCategory")]
        public virtual IActionResult AddSkillCategory([FromBody]SkillCategory body)
        { 
            var skillCategory = skillCategoryRepo.Add(body);
            skillCategoryRepo.SaveChanges();
            return Ok(mapper.Map<SkillCategoryDto>(skillCategory));
        }

        /// <summary>
        /// Deletes an Skill category
        /// </summary>
        /// <param name="skillCategoryId">ID of skill Category to return</param>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Pet not found</response>
        [HttpDelete]
        [Route("/v2/skillCategory/{skillCategoryId}")]
        
        [SwaggerOperation("DeleteSkillCategory")]
        public virtual IActionResult DeleteSkillCategory([FromRoute][Required]string skillCategoryId)
        { 
            skillCategoryRepo.Delete(skillCategoryId);
            skillCategoryRepo.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Fetch all the Skill Category
        /// </summary>
        /// <remarks>return all Skill Category</remarks>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid status value</response>
        [HttpGet]
        [Route("/v2/skillCategory")]
        
        [SwaggerOperation("GetAllSkillCategory")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<SkillCategory>), description: "successful operation")]
        public virtual IActionResult GetAllSkillCategory()
        {
            var allSkillCategories = skillCategoryRepo.GetAll(); 
            var result = new List<SkillCategoryDto>();
            foreach (var skillCategory in allSkillCategories)
            {
                result.Add(mapper.Map<SkillCategoryDto>(skillCategory));
            }
            return Ok(result);
        }

        /// <summary>
        /// Find Skill category by ID
        /// </summary>
        /// <remarks>Returns a single skill category</remarks>
        /// <param name="skillCategoryId">ID of skill Category to return</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Employee not found</response>
        [HttpGet]
        [Route("/v2/skillCategory/{skillCategoryId}")]
        
        [SwaggerOperation("GetSkillCategoryById")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<SkillCategory>), description: "successful operation")]
        public virtual IActionResult GetSkillCategoryById([FromRoute][Required]string skillCategoryId)
        {
            var skillCategory = skillCategoryRepo.GetById(skillCategoryId);
            if (skillCategory == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<SkillCategoryDto>(skillCategory));
        }

        /// <summary>
        /// Update an existing skill category
        /// </summary>
        /// <param name="body">Skill category object that needs to be updated</param>
        /// <param name="skillCategoryId">ID of skill Category to return</param>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Pet not found</response>
        /// <response code="405">Validation exception</response>
        [HttpPut]
        [Route("/v2/skillCategory")]
        
        [SwaggerOperation("UpdateSkillCategory")]
        public virtual IActionResult UpdateSkillCategory([FromBody]SkillCategory body)
        { 
            var updatedSkillCategories = skillCategoryRepo.Update(body);
            skillCategoryRepo.SaveChanges();
            return Ok(mapper.Map<SkillCategoryDto>(updatedSkillCategories));
        }
    }
}
