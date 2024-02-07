using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TasksAPI.CustomActionFilters;
using TasksAPI.Models.Domain;
using TasksAPI.Models.DTO;
using TasksAPI.Repositories;


namespace TasksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class BoardController : ControllerBase
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public BoardController(IBoardRepository boardRepository, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _boardRepository = boardRepository;
            _mapper = mapper;
            _userManager = userManager;
        }



        [HttpGet]
        [ValidateModel]
        public async Task<IActionResult> GetAll()
        {

            var userDetails = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;

            if (userDetails == null)
            {
                return BadRequest("UserDetails not found");
            }

            var user = await _userManager.FindByNameAsync(userDetails);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            string? UserId = user.Id;
            if (string.IsNullOrEmpty(UserId))
            {
                return BadRequest("userid is null");
            }
            var BoardsDomain = await _boardRepository.GetAllAsync(UserId);

            if (BoardsDomain == null)
            {
                return NotFound();
            }

            var boardDto = _mapper.Map<List<BoardDTO>>(BoardsDomain);

            return Ok(boardDto);

        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] BoardRequestDTO BoardRequestDTO)
        {

  

            var boardDomainModel = _mapper.Map<Board>(BoardRequestDTO);


            var userDetails = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;

            if (userDetails == null)
            {
                return BadRequest("UserDetails not found");
            }

            var user = await _userManager.FindByNameAsync(userDetails);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            string? Userid = user.Id;

           
            if(Userid == null)
            {
                return BadRequest("userId is null");
            }

            boardDomainModel.UserId = Userid;


            await _boardRepository.CreateAsync(boardDomainModel);

            return Ok(_mapper.Map<BoardDTO>(boardDomainModel));

        }

        [HttpPut]
        [Route("{id:int}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] int id, BoardRequestDTO boardRequestDTO)
        {
            var boardDomainModel = _mapper.Map<Board>(boardRequestDTO);

            boardDomainModel = await _boardRepository.UpdateAsync(id, boardDomainModel);

            if(boardDomainModel== null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<BoardDTO>(boardDomainModel));
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var existingBoard = await _boardRepository.DeleteAsync(id);

            if (existingBoard == null)
            {
                return NotFound();  
            }

            return Ok(_mapper.Map<BoardDTO>(existingBoard));
        }

        

    }

}
