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
    
    public class TaskLIstController : ControllerBase
    {
        private readonly ITaskListRepository _taskListRepository;
        private readonly IMapper _mapper;


        public TaskLIstController(ITaskListRepository taskListRepository, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _taskListRepository = taskListRepository;
            _mapper = mapper;
        }



        [HttpGet]
        [ValidateModel]
        [Route("{boardId:int}")]
        public async Task<IActionResult> GetAll([FromRoute] int boardId)
        {
            var taskListDomainModel = await _taskListRepository.GetAllAsync(boardId);

            var taskListDto = _mapper.Map<List<TaskListDTO>>(taskListDomainModel);

            return Ok(taskListDto); 

        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] TaskListRequestDTO taskListRequestDTO)
        {
            var tasklistDomainModel = _mapper.Map<TaskList>(taskListRequestDTO);

            await _taskListRepository.CreateAsync(tasklistDomainModel);

            return Ok(_mapper.Map<TaskListDTO>(tasklistDomainModel));
       
        }

        [HttpPut]
        [Route("{id:int}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] int id, TaskListRequestDTO taskListRequestDTO)
        {
            var taskListDomainModel = _mapper.Map<TaskList>(taskListRequestDTO);
            taskListDomainModel = await _taskListRepository.UpdateAsync(id, taskListDomainModel);

            if(taskListDomainModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TaskListDTO>(taskListDomainModel));
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var existingTaskList = await _taskListRepository.DeleteAsync(id);

            if (existingTaskList == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TaskListDTO>(existingTaskList));
        }


    }
}
