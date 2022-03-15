
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
    public class DepartmentApiController : ControllerBase
    {
        private IRepository<Department> departmentRepo { get; set; }
        private IMapper mapper;

        public DepartmentApiController(IRepository<Department> departmentRepo, IMapper mapper)
        {
            this.departmentRepo = departmentRepo;
            this.mapper = mapper;
        }
        [HttpPost]
        [Route("/v2/department")]

        [SwaggerOperation("AddDepartment")]
        public virtual IActionResult AddDepartment([FromBody] DepartmentDto body)
        {
            var entity = mapper.Map<Department>(body);
            var department = departmentRepo.Add(entity);
            departmentRepo.SaveChanges();
            return Ok(mapper.Map<DepartmentDto>(department));
        }

        [HttpDelete]
        [Route("/v2/department/{departmentId}")]

        [SwaggerOperation("DeleteDepartment")]
        public virtual IActionResult DeleteDepartment([FromRoute][Required] string Id)
        {
            departmentRepo.Delete(Id);
            departmentRepo.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("/v2/department")]

        [SwaggerOperation("GetAllDepartments")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Department>), description: "successful operation")]
        public virtual IActionResult GetAllContractStatuses()
        {
            var alldepartments = departmentRepo.GetAll();
            var result = new List<DepartmentDto>();  
            foreach (var department in alldepartments)
            {
                result.Add(mapper.Map<DepartmentDto>(department));
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("/v2/department/{departmentId}")]

        [SwaggerOperation("GetDepartmentById")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Department>), description: "successful operation")]
        public virtual IActionResult GetDepartmentById([FromRoute][Required] string Id)
        {
            var department = departmentRepo.GetById(Id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<DepartmentDto>(department));
        }

        /// <summary>
        /// Update an existing contractStatus
        /// </summary>
        /// <param name="body">ContractStatus object that needs to be updated</param>
        /// <param name="contractStatusId">ID of skill Category to return</param>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">ContractStatus not found</response>
        /// <response code="405">Validation exception</response>
        [HttpPut]
        [Route("/v2/department")]

        [SwaggerOperation("UpdateDepartment")]
        public virtual IActionResult UpdateDepartment([FromBody] Department body)
        {
            var updatedDepartment = departmentRepo.Update(body);
            return Ok(mapper.Map<DepartmentDto>(updatedDepartment));
        }
    }
}
