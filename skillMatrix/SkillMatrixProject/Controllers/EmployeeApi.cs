
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using SkillMatrixProject.Repositories;
using SkillMatrixProject.Models;
using SkillMatrixProject.Services;
using SkillMatrixProject.DTOs;
using AutoMapper;

namespace skillMatrix.WebAPI.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class EmployeeApiController : ControllerBase
    {
        private IRepository<Employee> employeeRepo { get; set; }
        private ISkillService skillService { get; set; }
        private readonly IMapper mapper;
        public EmployeeApiController(ISkillService skillService, IRepository<Employee> employeeRepo, IMapper mapper)
        {
            this.employeeRepo = employeeRepo;
            this.skillService = skillService;
            this.mapper = mapper;
        }
        /// <summary>
        /// Add a new employee to the store
        /// </summary>
        /// <param name="body">employee object that needs to be added to the application</param>
        /// <response code="405">Invalid input</response>
        [HttpPost]
        
        [Route("/v2/employee")]
        [SwaggerOperation("AddEmployee")]
        public virtual IActionResult AddEmployee([FromBody] Employee body)
        {
            
            var addedEmp = employeeRepo.Add(body);
            employeeRepo.SaveChanges();
            
            return Ok(mapper.Map<EmployeeDto>(addedEmp));
        }

        /// <summary>
        /// Deletes an employee
        /// </summary>
        /// <param name="employeeId">ID of employee to return</param>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Pet not found</response>
        [HttpDelete]
        [Route("/v2/employee/{employeeId}")]
        [SwaggerOperation("DeleteEmployee")]
        public virtual IActionResult DeleteEmployee([FromRoute][Required]string employeeId)
        { 
            var employee = employeeRepo.GetById(employeeId);
            if (employee == null)
            {
                return NotFound();
            }
            employeeRepo.Delete(employeeId);
            employeeRepo.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Fetch all the Employees
        /// </summary>
        /// <remarks>return all employees</remarks>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid status value</response>
        [HttpGet]
        [Route("/v2/employee")]
        
        [SwaggerOperation("GetAllEmployee")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Employee>), description: "successful operation")]
        public virtual IActionResult GetAllEmployee()
        {
            var allEmployees = employeeRepo.GetAll();
            List<EmployeeDto> employeeList = new List<EmployeeDto>();
            foreach (var item in allEmployees)
            {
                employeeList.Add(skillService.GetEmployeeWithSkills(item.Id));
            }
            return Ok(employeeList);
        }

        [HttpGet]
        [Route("/v2/employee/{employeeId}")]

        [SwaggerOperation("GetEmployeeById")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Employee>), description: "successful operation")]
        public virtual IActionResult GetEmployeeById([FromRoute][Required] string employeeId)
        {
            
           var employee = skillService.GetEmployeeWithSkills(employeeId);
            
            
            return Ok(employee);
        }

        [HttpPost]
        [Route("/v2/employeeSkills/{employeeId}/{skillId}")]
        [SwaggerOperation("AddSkillToEmployee")]
        public virtual IActionResult AddSkillToEmployee([FromRoute][Required] string employeeId, [FromRoute][Required] string skillId)
        {   
            skillService.AddSkill(employeeId, skillId);
           
            return Ok();
        }

        [HttpGet]
        [Route("/v2/employeeSkills/{employeeId}")]
        [SwaggerOperation("GetSkillOfEmployee")]
        public virtual IActionResult GetSkillOfEmployee([FromRoute][Required] string employeeId)
        {
            var skills = skillService.GetSkills(employeeId);
            
            return Ok(skills);
        }
        [HttpDelete]
        [Route("/v2/employeeSkills/{employeeId}/{skillId}")]
        [SwaggerOperation("DeleteSkillFromEmployee")]
        public virtual IActionResult DeleteSkillFromEmployee([FromRoute][Required] string employeeId,
                                                             [FromRoute][Required] string skillId)
        {
            
            skillService.DeleteSkill(employeeId, skillId);
            
            return Ok();
        }
        [HttpPut]
        [Route("/v2/employeeSkills/{employeeId}/{skillId}/{skillLevelId}")]
        [SwaggerOperation("UpdateSkillLevelEmployee")]
        public virtual IActionResult UpdateSkillLevelEmployee([FromRoute][Required] string employeeId, 
                                                              [FromRoute][Required] string skillId,
                                                              [FromRoute][Required] string skillLevelId
                                                              )
        {
            skillService.UpdateSkillLevel(employeeId, skillId, skillLevelId);
            return Ok();
        }
        
        

        /// <summary>
        /// Update an existing employee
        /// </summary>
        /// <param name="body">Employee object that needs to be added to the application</param>
        /// <param name="employeeId">ID of employee to return</param>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Pet not found</response>
        /// <response code="405">Validation exception</response>
        [HttpPatch]
        [Route("/v2/employee/{employeeId}")]
        
        [SwaggerOperation("UpdateEmployee")]
        public virtual IActionResult UpdateEmployee([FromRoute][Required] string employeeId, [FromBody] JsonPatchDocument<Employee> patchDocument)
        { 
            var Employee = employeeRepo.GetById(employeeId);
            patchDocument.ApplyTo(Employee);
            var updatedEmployee = employeeRepo.Update(Employee);
            employeeRepo.SaveChanges();
            return Ok(mapper.Map<EmployeeDto>(updatedEmployee)); 
        }
    }
}
