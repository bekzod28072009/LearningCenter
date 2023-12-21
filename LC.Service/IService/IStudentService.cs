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
    public interface IStudentService
    {
        IQueryable<Student> GetAll(Expression<Func<Student, bool>> expression, string[] includes = null);
        ValueTask<StudentDto> GetAsync(Expression<Func<Student, bool>> expression, string[] includes = null);
        ValueTask<StudentDto> CreateAsync(StudentDto entity);
        ValueTask<bool> DeleteAsync(Expression<Func<Student, bool>> expression);
        StudentDto Update(int id, StudentDto entity);
    }
}
