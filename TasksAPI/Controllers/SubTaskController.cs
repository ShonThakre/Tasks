using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TasksAPI.CustomActionFilters;
using TasksAPI.Models.Domain;
using TasksAPI.Models.DTO;
using TasksAPI.Repositories;
using TasksAPI.Repositories.IRepositories;

namespace TasksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class SubTaskController : ControllerBase
    {
        private readonly ISubTaskRepository _subTaskRepository;
        private readonly IMapper _mapper;


        public SubTaskController(ISubTaskRepository subTaskRepository, IMapper mapper)
        {
            _subTaskRepository = subTaskRepository;
            _mapper = mapper;
        }


        [HttpGet]
        [ValidateModel]
        [Route("{mainTaskId:int}")]
        public async Task<IActionResult> GetAll([FromRoute] int mainTaskId)
        {
            var subTaskDomainModel = await _subTaskRepository.GetAllAsync(mainTaskId);

            if (subTaskDomainModel == null)
            {
                return NotFound();
            }

            var subTaskDto = _mapper.Map<List<SubTaskDTO>>(subTaskDomainModel);

            return Ok(subTaskDto); 

        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] SubTaskRequestDTO subTaskRequestDTO)
        {
            var subTaskDomainModel = _mapper.Map<SubTask>(subTaskRequestDTO);

            await _subTaskRepository.CreateAsync(subTaskDomainModel);

            return Ok(_mapper.Map<SubTaskDTO>(subTaskDomainModel));
       
        }

        [HttpPut]
        [Route("{id:int}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] int id, SubTaskRequestDTO subTaskRequestDTO)
        {
            var subTaskDomainModel = _mapper.Map<SubTask>(subTaskRequestDTO);
            subTaskDomainModel = await _subTaskRepository.UpdateAsync(id, subTaskDomainModel);

            if(subTaskDomainModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<SubTaskDTO>(subTaskDomainModel));
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var existingsubTask = await _subTaskRepository.DeleteAsync(id);

            if (existingsubTask == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<SubTaskDTO>(existingsubTask));
        }


    }
}
