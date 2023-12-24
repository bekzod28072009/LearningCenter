using LC.Domein.Entities.Courses;
using LC.Domein.Entities.Students;
using LC.Service.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LC.Service.IService
{
    public interface ICourseService
    {
        IQueryable<Course> GetAll(Expression<Func<Course, bool>> expression, string[] includes = null);
        ValueTask<CourseDto> GetAsync(Expression<Func<Course, bool>> expression, string[] includes = null);
        ValueTask<CourseDto> CreateAsync(CourseDto entity);
        ValueTask<bool> DeleteAsync(Expression<Func<Course, bool>> expression);
        CourseDto Update(int id, CourseDto entity);
    }
}
