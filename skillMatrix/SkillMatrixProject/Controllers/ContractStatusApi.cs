using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

using Swashbuckle.AspNetCore.Annotations;
using Newtonsoft.Json;
using SkillMatrixProject.Repositories;
using SkillMatrixProject.Models;
using AutoMapper;
using SkillMatrixProject.DTOs;

namespace skillMatrix.WebAPI.Controllers
{ 
    [ApiController]
    public class ContractStatusApiController : ControllerBase
    {
        private IRepository<ContractStatus> contractStatusRepo { get; set; }
        private readonly IMapper mapper;

        public ContractStatusApiController(IRepository<ContractStatus> contractStatusRepo, IMapper mapper)
        {
            this.contractStatusRepo = contractStatusRepo;
            this.mapper = mapper;
        }
        [HttpPost]
        [Route("/v2/contractStatus")]
       
        [SwaggerOperation("AddContractStatus")]
        public virtual IActionResult AddContractStatus([FromBody]ContractStatus body)
        {
            ContractStatus contractStatus = contractStatusRepo.Add(body);
            contractStatusRepo.SaveChanges();
            
            return Ok(mapper.Map<ContractStatusDto>(contractStatus));
        }

        [HttpDelete]
        [Route("/v2/contractStatus/{contractStatusId}")]
       
        [SwaggerOperation("DeleteContractStatus")]
        public virtual IActionResult DeleteContractStatus([FromRoute][Required]string contractStatusId)
        {
            contractStatusRepo.Delete(contractStatusId);
            contractStatusRepo.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("/v2/contractStatus")]
        
        [SwaggerOperation("GetAllContractStatuses")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<ContractStatus>), description: "successful operation")]
        public virtual IActionResult GetAllContractStatuses()
        {
            var allContractStatuses = contractStatusRepo.GetAll();
            var result = new List<ContractStatusDto>();
            foreach (var item in allContractStatuses)
            {
                result.Add(mapper.Map<ContractStatusDto>(item));
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("/v2/contractStatus/{contractStatusId}")]
      
        [SwaggerOperation("GetContractStatusById")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<ContractStatus>), description: "successful operation")]
        public virtual IActionResult GetContractStatusById([FromRoute][Required]string contractStatusId)
        {
            var contractStatus = contractStatusRepo.GetById(contractStatusId);

            return Ok(mapper.Map<ContractStatusDto>(contractStatus));
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
        [Route("/v2/contractStatus")]
        
        [SwaggerOperation("UpdateContractStatus")]
        public virtual IActionResult UpdateContractStatus([FromBody]ContractStatus body)
        {
            var updatedContractStatus = contractStatusRepo.Update(body);

            return Ok(mapper.Map<ContractStatusDto>(updatedContractStatus));
        }
    }
}
