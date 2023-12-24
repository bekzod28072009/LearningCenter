using LC.Domein.Entities.Students;
using LC.Domein.Entities.Teachers;
using LC.Service.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LC.Service.IService
{
    public interface ITeacherService
    {
        IQueryable<Teacher> GetAll(Expression<Func<Teacher, bool>> expression, string[] includes = null);
        ValueTask<TeacherDto> GetAsync(Expression<Func<Teacher, bool>> expression, string[] includes = null);
        ValueTask<TeacherDto> CreateAsync(TeacherDto entity);
        ValueTask<bool> DeleteAsync(Expression<Func<Teacher, bool>> expression);
        TeacherDto Update(int id, TeacherDto entity);
    }
}
