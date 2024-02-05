using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasksAPI.Models.Domain;
using TasksAPI.Models.DTO;
using TasksAPI.Repositories;

namespace TasksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly BoardRepository _boardRepository;
        private readonly IMapper _mapper;

        public BoardController(BoardRepository boardRepository, IMapper mapper)
        {
            _boardRepository = boardRepository;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult> GetAll() {

            var BoardsDomain = await _boardRepository.GetAllAsync();

           var boardDto = _mapper.Map<List<BoardDTO>>(BoardsDomain);

            return Ok(boardDto);

        }
    }
}
