
using AutoMapper;
using Backend.Dtos.CourseDtos;
using Backend.Dtos.CourseFoldersDtos;
using Backend.Dtos.UserDtos;
using Backend.Models;


namespace Backend.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Course, CreateCourseInfoDto>().ReverseMap();
            CreateMap<Course, UpdateCourseInfoDto>().ReverseMap();
            CreateMap<CourseFolders, CreateCourseFoldersDto>().ReverseMap();
            CreateMap<CourseFolders, UpdateCourseFolderNameDto>().ReverseMap();
        }
    }
}

