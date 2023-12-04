
using AutoMapper;
using Backend.Dtos.CourseDtos;
using Backend.Dtos.CourseFoldersDtos;
using Backend.Dtos.CourseVideoDtos;
using Backend.Dtos.UserDtos;
using Backend.Models;


namespace Backend.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();

            CreateMap<Course, CreateCourseInfoDto>().ReverseMap();
            CreateMap<Course, UpdateCourseInfoDto>().ReverseMap();
            CreateMap<Course, CourseInfoDto>().ReverseMap();

            CreateMap<CourseFolders, CourseFoldersDto>().ReverseMap();
            CreateMap<CourseFolders, CreateCourseFoldersDto>().ReverseMap();
            CreateMap<CourseFolders, UpdateCourseFolderNameDto>().ReverseMap();

            CreateMap<CourseVideo, CourseVideoDto>().ReverseMap();
            CreateMap<CourseVideo, CreateCourseVideoDto>().ReverseMap();
            CreateMap<CourseVideo, UpdateCourseVideoDto>().ReverseMap();
        }
    }
}

