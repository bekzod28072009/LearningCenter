using AutoMapper;
using LC.Domein.Entities.Courses;
using LC.Domein.Entities.Students;
using LC.Domein.Entities.Teachers;
using LC.Service.Dto_s;

namespace LearningCenterAPI.Configuration
{
    public class MapConfiguration : Profile
    {
        public MapConfiguration()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Teacher, TeacherDto>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
        }
    }
}
