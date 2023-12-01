
using AutoMapper;
using Backend.Dtos.UserDtos;
using Backend.Models;


namespace Backend.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}

