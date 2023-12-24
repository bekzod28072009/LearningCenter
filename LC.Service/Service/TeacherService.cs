using AutoMapper;
using LC.DataAcces.Interfaces;
using LC.Domein.Entities.Students;
using LC.Domein.Entities.Teachers;
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
    public class TeacherService : ITeacherService
    {
        private readonly IGenericRepository<Teacher> repository;
        private readonly IMapper mapper;
        public TeacherService(IGenericRepository<Teacher> repository,
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async ValueTask<TeacherDto> CreateAsync(TeacherDto entity)
        {
            var teacher = new Teacher();
            if (entity is not null)
            {
                var teacher1 = mapper.Map<Teacher>(entity);
                var newTeacher = await repository.CreateAsync(teacher1);
            }
            repository.SaveChangesAsync();
            return mapper.Map<TeacherDto>(teacher);
        }

        public async ValueTask<bool> DeleteAsync(Expression<Func<Teacher, bool>> expression)
        {
            bool res = await repository.DeleteAsync(expression);
            await repository.SaveChangesAsync();
            return res;
        }

        public IQueryable<Teacher> GetAll(Expression<Func<Teacher, bool>> expression, string[] includes = null)
            => repository.GetAll(expression, includes);

        public async ValueTask<TeacherDto> GetAsync(Expression<Func<Teacher, bool>> expression, string[] includes = null)
        {
            var teacher = repository.GetAsync(expression, includes);
            return mapper.Map<TeacherDto>(teacher);
        }

        public TeacherDto Update(int id, TeacherDto entity)
        {
            var teacher = mapper.Map<Teacher>(entity);
            teacher.Id = id;
            var UpdateUser = repository.Update(teacher);
            repository.SaveChangesAsync();
            return mapper.Map<TeacherDto>(UpdateUser);
        }
    }
}
