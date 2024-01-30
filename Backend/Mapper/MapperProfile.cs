
using AutoMapper;
using Backend.Dtos.CourseDtos;
using Backend.Dtos.CourseFoldersDtos;
using Backend.Dtos.CourseVideoDtos;
using Backend.Dtos.InterestDtos;
using Backend.Dtos.TagDtos;
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

            CreateMap<Interests, InterestDto>().ReverseMap();
            CreateMap<Interests, CreateInterestDto>().ReverseMap();
            CreateMap<Interests, UpdateInterestDto>().ReverseMap();

            CreateMap<Tags, TagDto>().ReverseMap();
            CreateMap<Tags, CreateTagDto>().ReverseMap();
            CreateMap<Tags, UpdateTagDto>().ReverseMap();
        }
    }
}

