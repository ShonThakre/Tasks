using AutoMapper;
using TasksAPI.Models.Domain;
using TasksAPI.Models.DTO;

namespace TasksAPI.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<BoardDTO, Board>().ReverseMap();
            CreateMap<Board, BoardRequestDTO>().ReverseMap();
            CreateMap<TaskListDTO, TaskList>().ReverseMap();
            CreateMap<TaskListRequestDTO, TaskList>().ReverseMap();
        }
    }
}
