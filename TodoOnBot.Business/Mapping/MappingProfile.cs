using AutoMapper;
using TodoOnBot.Business.Models;
using TodoOnBot.Data.Models;

namespace TodoOnBot.Business.Mapping
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<TodoDto, Todo>().ReverseMap();
        }
    }
}