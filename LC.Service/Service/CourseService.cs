using AutoMapper;
using LC.DataAcces.Interfaces;
using LC.Domein.Entities.Courses;
using LC.Domein.Entities.Students;
using LC.Service.Dto_s;
using LC.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LC.Service.Service
{
    public class CourseService : ICourseService
    {
        private readonly IGenericRepository<Course> repository;
        private readonly IMapper mapper;
        public CourseService(IGenericRepository<Course> repository,
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async ValueTask<CourseDto> CreateAsync(CourseDto entity)
        {
            var course = new Course();
            if (entity is not null)
            {
                var course1 = mapper.Map<Course>(entity);
                var newCourse = await repository.CreateAsync(course1);
            }
            repository.SaveChangesAsync();
            return  mapper.Map<CourseDto>(course);
        }

        public async ValueTask<bool> DeleteAsync(Expression<Func<Course, bool>> expression)
        {
            bool res = await repository.DeleteAsync(expression);
            await repository.SaveChangesAsync();
            return res;
        }

        public IQueryable<Course> GetAll(Expression<Func<Course, bool>> expression, string[] includes = null)
            => repository.GetAll(expression, includes);

        public async ValueTask<CourseDto> GetAsync(Expression<Func<Course, bool>> expression, string[] includes = null)
        {
            var course = repository.GetAsync(expression, includes);
            return mapper.Map<CourseDto>(course);
        }

        public CourseDto Update(int id, CourseDto entity)
        {
            var course = mapper.Map<Course>(entity);
            course.Id = id;
            var UpdateCourse = repository.Update(course);
            repository.SaveChangesAsync();
            return mapper.Map<CourseDto>(UpdateCourse);
        }
    }
}
