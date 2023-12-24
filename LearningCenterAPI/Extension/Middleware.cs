using LC.DataAcces.AppDbContext;
using LC.DataAcces.Interfaces;
using LC.DataAcces.Repositories;
using LC.Domein.Entities.Courses;
using LC.Domein.Entities.Students;
using LC.Domein.Entities.Teachers;
using LC.Service.IService;
using LC.Service.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LearningCenterAPI.Extension
{
    public static class Middleware
    {
        public static void AddDBConTextes(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LearningCenterDbContext>(options =>
                 options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        }
        public static void AddService(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<ITeacherService, TeacherService>();
        }
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IGenericRepository<Student>, GenericRepository<Student>>();
            services.AddTransient<IGenericRepository<Course>, GenericRepository<Course>>();
            services.AddTransient<IGenericRepository<Teacher>, GenericRepository<Teacher>>();
        }
    }
}
