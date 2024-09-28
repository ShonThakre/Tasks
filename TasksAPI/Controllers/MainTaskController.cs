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
    
    public class MainTaskController : ControllerBase
    {
        private readonly IMainTaskRepository _mainTaskRepository;
        private readonly IMapper _mapper;


        public MainTaskController(IMainTaskRepository mainTaskRepository, IMapper mapper)
        {
            _mainTaskRepository = mainTaskRepository;
            _mapper = mapper;
        }



        [HttpGet]
        [ValidateModel]
        [Route("{taskListId:int}")]
        public async Task<IActionResult> GetAll([FromRoute] int taskListId)
        {
            var mainTaskDomainModel = await _mainTaskRepository.GetAllAsync(taskListId);

            if (mainTaskDomainModel == null)
            {
                return NotFound();
            }

            var mainTaskDto = _mapper.Map<List<MainTaskDTO>>(mainTaskDomainModel);

            return Ok(mainTaskDto); 

        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] MainTaskRequestDTO mainTaskRequestDTO)
        {
            var mainTaskDomainModel = _mapper.Map<MainTask>(mainTaskRequestDTO);

            await _mainTaskRepository.CreateAsync(mainTaskDomainModel);

            return Ok(_mapper.Map<MainTaskDTO>(mainTaskDomainModel));
       
        }

        [HttpPut]
        [Route("{id:int}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] int id, MainTaskRequestDTO mainTaskRequestDTO)
        {
            var mainTaskDomainModel = _mapper.Map<MainTask>(mainTaskRequestDTO);
            mainTaskDomainModel = await _mainTaskRepository.UpdateAsync(id, mainTaskDomainModel);

            if(mainTaskDomainModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<MainTaskDTO>(mainTaskDomainModel));
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var existingMainTask = await _mainTaskRepository.DeleteAsync(id);

            if (existingMainTask == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<MainTaskDTO>(existingMainTask));
        }


    }
}
