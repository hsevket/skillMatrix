
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
    public class EmploymentStatusApiController : ControllerBase
    { 
        private IRepository<EmploymentStatus> employmentStatusRepo { get; set; }
        private IMapper mapper;
        public EmploymentStatusApiController(IRepository<EmploymentStatus> employmentStatusRepo, IMapper mapper)
        {
            this.employmentStatusRepo = employmentStatusRepo;
            this.mapper = mapper;
        }
        /// <summary>
        /// Add a new EmploymentStatus to the application
        /// </summary>
        /// <param name="body">EmploymentStatus object that needs to be added to the application</param>
        /// <response code="405">Invalid input</response>
        [HttpPost]
        [Route("/v2/employmentStatus")]
       
        [SwaggerOperation("AddEmploymentStatus")]
        public virtual IActionResult AddEmploymentStatus([FromBody]EmploymentStatusDto body)
        {
            var entity = mapper.Map<EmploymentStatus>(body);
            EmploymentStatus employmentStatus = employmentStatusRepo.Add(entity);
            employmentStatusRepo.SaveChanges();

            return Ok(mapper.Map<EmploymentStatusDto>(employmentStatus));
        }

        /// <summary>
        /// Deletes an EmploymentStatus
        /// </summary>
        /// <param name="employmentStatusId">ID of EmploymentStatus to return</param>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">ContractStatus not found</response>
        [HttpDelete]
        [Route("/v2/employmentStatus/{employmentStatusId}")]
       
        [SwaggerOperation("DeleteEmploymentStatus")]
        public virtual IActionResult DeleteEmploymentStatus([FromRoute][Required]string employmentStatusId)
        {
            employmentStatusRepo.Delete(employmentStatusId);
            employmentStatusRepo.SaveChanges();
            return Ok();

        }

        /// <summary>
        /// Fetch all the employmentStatus
        /// </summary>
        /// <remarks>return all employmentStatuses</remarks>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid status value</response>
        [HttpGet]
        [Route("/v2/employmentStatus")]
        
        [SwaggerOperation("GetAllEmploymentStatus")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<EmploymentStatus>), description: "successful operation")]
        public virtual IActionResult GetAllEmploymentStatus()
        {
            var allEmploymentStatus = employmentStatusRepo.GetAll();
            var result = new List<EmploymentStatusDto>();
            foreach (var employmentStatus in allEmploymentStatus)
            {
                result.Add(mapper.Map<EmploymentStatusDto>(employmentStatus));
            }
            return Ok(result);
        }

        /// <summary>
        /// Find EmploymentStatus by ID
        /// </summary>
        /// <remarks>Returns a single EmploymentStatus</remarks>
        /// <param name="employmentStatusId">ID of EmploymentStatus to return</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">EmploymentStatus not found</response>
        [HttpGet]
        [Route("/v2/employmentStatus/{employmentStatusId}")]
       
        [SwaggerOperation("GetEmploymentStatusById")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<EmploymentStatus>), description: "successful operation")]
        public virtual IActionResult GetEmploymentStatusById([FromRoute][Required]string employmentStatusId)
        { 
            var employmentStatus = employmentStatusRepo.GetById(employmentStatusId);
            if (employmentStatus == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<EmploymentStatusDto>(employmentStatus));
        }

        /// <summary>
        /// Update an existing EmploymentStatus
        /// </summary>
        /// <param name="body">EmploymentStatus object that needs to be updated</param>
        /// <param name="employmentStatusId">ID of EmploymentStatus to return</param>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">ContractStatus not found</response>
        /// <response code="405">Validation exception</response>
        [HttpPut]
        [Route("/v2/employmentStatus/{employmentStatusId}")]
        
        [SwaggerOperation("UpdateEmploymentStatus")]
        public virtual IActionResult UpdateEmploymentStatus([FromBody]EmploymentStatus body, [FromRoute][Required]EmploymentStatus employmentStatusId)
        {
            var updatedEmploymentStatus = employmentStatusRepo.Update(body);
            return Ok(mapper.Map<EmploymentStatusDto>(updatedEmploymentStatus));
        }
    }
}
