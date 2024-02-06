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
        public async Task<IActionResult> Create([FromBody] TaskListDTO taskListDTO)
        {
            var tasklistDomainModel = _mapper.Map<TaskList>(taskListDTO);

            await _taskListRepository.CreateAsync(tasklistDomainModel);

            return Ok(_mapper.Map<TaskListDTO>(tasklistDomainModel));
       
        }

        [HttpPut]
        [Route("{id:int}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] int id, BoardRequestDTO boardRequestDTO)
        {
            
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var existingBoard = await _taskListRepository.DeleteAsync(id);

            if (existingBoard == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BoardDTO>(existingBoard));
        }


    }
}
