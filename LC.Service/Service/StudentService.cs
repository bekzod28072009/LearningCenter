using AutoMapper;
using LC.DataAcces.Interfaces;
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
    public class StudentService : IStudentService
    {
        private readonly IGenericRepository<Student> repository;
        private readonly IMapper mapper;

        public StudentService(IGenericRepository<Student> repository,
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async ValueTask<StudentDto> CreateAsync(StudentDto entity)
        {
            var student = new Student();
            if (entity is not null)
            {

                var student1 = mapper.Map<Student>(entity);
                var newstudent = await repository.CreateAsync(student1);
            }
            repository.SaveChangesAsync();
            return mapper.Map<StudentDto>(student);
        }

        public async ValueTask<bool> DeleteAsync(Expression<Func<Student, bool>> expression)
        {
            bool res = await repository.DeleteAsync(expression);
            await repository.SaveChangesAsync();
            return res;
        }

        public IQueryable<Student> GetAll(Expression<Func<Student, bool>> expression, string[] includes = null)
            => repository.GetAll(expression, includes);

        public async ValueTask<StudentDto> GetAsync(Expression<Func<Student, bool>> expression, string[] includes = null)
        {
            var student = repository.GetAsync(expression, includes);
            return mapper.Map<StudentDto>(student);
        }

        public StudentDto Update(int id, StudentDto entity)
        {
            var student = mapper.Map<Student>(entity);
            student.Id = id;
            var UpdateUser = repository.Update(student);
            repository.SaveChangesAsync();
            return mapper.Map<StudentDto>(UpdateUser);
        }
    }
}
