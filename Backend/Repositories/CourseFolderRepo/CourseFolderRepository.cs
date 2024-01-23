
using AutoMapper;
using Backend.Dtos.CourseDtos;
using Backend.Dtos.CourseFoldersDtos;
using Backend.Exceptions;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.CourseFolderRepo
{
    public class CourseFolderRepository : ICourseFolderRepository
    {

        private readonly ProjectAppContext _context;
        private readonly IMapper _mapper;

        public CourseFolderRepository(ProjectAppContext _ctx, IMapper map)
        {
            _context = _ctx;
            _mapper = map;
        }

        public CourseFoldersDto AddVideoToCourseFolder(long courseFolderId, long courseVideoId)
        {
            CourseFolders courseFolders = _context.CourseFolders.Find(courseFolderId);

            if (courseFolders == null)
            {
                throw new NotFoundException("Course Folder not found");
            }

            CourseVideo courseVideo = _context.CourseVideos.Find(courseVideoId);

            if (courseVideo == null)
            {
                throw new NotFoundException("Course Video not found");
            }

            if (courseFolders.CourseVideos.Contains(courseVideo))
            {
                throw new BadRequestException("Course Folder already contains this video");
            }

            courseFolders.CourseVideos.Add(courseVideo);
            _context.SaveChanges();

            return _mapper.Map<CourseFoldersDto>(courseFolders);
        }

        public CourseFoldersDto CreateCourseFolder(long courseId, CreateCourseFoldersDto courseFolder)
        {

            Course? course = _context.Courses.Find(courseId);

            if (course == null)
            {
                throw new NotFoundException("Course not found");
            }

            CourseFolders courseFolders = _mapper.Map<CourseFolders>(courseFolder);
            courseFolders.CourseId = courseId;

            _context.CourseFolders.Add(courseFolders);
            _context.SaveChanges();

            return _mapper.Map<CourseFoldersDto>(courseFolders);
        }

        public bool DeleteCourseFolderById(long id)
        {
            CourseFolders courseFolders = _context.CourseFolders.Find(id);

            if (courseFolders == null)
            {
                throw new NotFoundException("Course Folder not found");
            }

            if (courseFolders.CourseVideos.Count > 0)
            {
                throw new BadRequestException("Course Folder has videos in it");
            }


            _context.CourseFolders.Remove(courseFolders);
            _context.SaveChanges();

            return true;
        }

        public IEnumerable<CourseFoldersDto> GetAllCourseFoldersOfCourse(long courseId)
        {
            IEnumerable<CourseFolders> courseFolders = _context.CourseFolders.Where(cf => cf.CourseId == courseId).Include(cf => cf.CourseVideos);

            return _mapper.Map<IEnumerable<CourseFoldersDto>>(courseFolders);
        }

        public CourseFoldersDto GetCourseFolderByIdAlongWithCourseVideos(long id)
        {
            CourseFolders courseFolders = _context.CourseFolders.Where(cf => cf.ID == id).Include(cf => cf.CourseVideos).FirstOrDefault();

            if (courseFolders == null)
            {
                throw new NotFoundException("Course Folder not found");
            }

            return _mapper.Map<CourseFoldersDto>(courseFolders);
        }

        public CourseFoldersDto RemoveVideoFromCourseFolder(long courseFolderId, long courseVideoId)
        {
            CourseFolders courseFolders = _context.CourseFolders.Find(courseFolderId);

            if (courseFolders == null)
            {
                throw new NotFoundException("Course Folder not found");
            }

            CourseVideo courseVideo = _context.CourseVideos.Find(courseVideoId);

            if (courseVideo == null)
            {
                throw new NotFoundException("Course Video not found");
            }

            if (!courseFolders.CourseVideos.Contains(courseVideo))
            {
                throw new BadRequestException("Course Folder does not contain this video");
            }

            courseFolders.CourseVideos.Remove(courseVideo);
            _context.SaveChanges();

            return _mapper.Map<CourseFoldersDto>(courseFolders);
        }

        public CourseFoldersDto UpdateCourseFolder(UpdateCourseInfoDto courseFolder)
        {

            CourseFolders courseFolders = _context.CourseFolders.Find(courseFolder.ID);

            if (courseFolders == null)
            {
                throw new NotFoundException("Course Folder not found");
            }

            _mapper.Map(courseFolder, courseFolders);
            _context.SaveChanges();

            return _mapper.Map<CourseFoldersDto>(courseFolders);
        }
    }
}