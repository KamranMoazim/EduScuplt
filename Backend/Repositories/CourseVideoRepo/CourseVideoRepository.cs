
using AutoMapper;
using Backend.Dtos.CourseVideoDtos;
using Backend.Exceptions;
using Backend.Models;

namespace Backend.Repositories.CourseVideoRepo
{
    public class CourseVideoRepository : ICourseVideoRepository
    {
        private readonly ProjectAppContext _context;
        private readonly IMapper _mapper;

        public CourseVideoRepository(ProjectAppContext _ctx, IMapper map)
        {
            _context = _ctx;
            _mapper = map;
        }


        public CourseVideoDto CreateCourseVideo(CreateCourseVideoDto courseVideo)
        {
            CourseVideo courseVideoToCreate = _mapper.Map<CourseVideo>(courseVideo);

            _context.CourseVideos.Add(courseVideoToCreate);
            _context.SaveChanges();

            return _mapper.Map<CourseVideoDto>(courseVideoToCreate);
        }


        public bool DeleteCourseVideoById(long id)
        {

            CourseVideo? courseVideo = _context.CourseVideos.Find(id);

            if (courseVideo == null)
            {
                throw new NotFoundException("Course Video not found");
            }


            // check if course video is in any course folder and throw exception if it is
            foreach (CourseFolders courseFolder in _context.CourseFolders)
            {
                if (courseFolder.CourseVideos.Contains(courseVideo))
                {
                    throw new BadRequestException("Course Video is in a course folder, delete it from the course folder first");
                }
            }


            _context.CourseVideos.Remove(courseVideo);
            _context.SaveChanges();

            return true;
        }

        public CourseVideoDto GetCourseVideoById(long id)
        {

            CourseVideo? courseVideo = _context.CourseVideos.Find(id);

            if (courseVideo == null)
            {
                throw new NotFoundException("Course Video not found");
            }

            return _mapper.Map<CourseVideoDto>(courseVideo);
        }

        public CourseVideoDto UpdateCourseVideo(UpdateCourseVideoDto courseVideo)
        {
                
            CourseVideo? courseVideoToUpdate = _context.CourseVideos.Find(courseVideo.ID);

            if (courseVideoToUpdate == null)
            {
                throw new NotFoundException("Course Video not found");
            }

            courseVideoToUpdate = _mapper.Map(courseVideo, courseVideoToUpdate);

            _context.SaveChanges();

            return _mapper.Map<CourseVideoDto>(courseVideoToUpdate);
        }
    }
}