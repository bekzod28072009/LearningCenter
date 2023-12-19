using LC.DataAcces.AppDbContext;
using LC.DataAcces.Interfaces;
using LC.Domein.Commons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LC.DataAcces.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Auditable
    {
        private readonly LearningCenterDbContext dbContext;
        private readonly DbSet<T> dbSet;
        public GenericRepository(LearningCenterDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }
        public async ValueTask<T> CreateAsync(T entity) =>
            (await dbContext.AddAsync(entity)).Entity;

        public async ValueTask<bool> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            var entity = await GetAsync(expression);

            if (entity == null)
            {
                return false;
            }
            dbSet.Remove(entity);
            return true;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            IQueryable<T> query = expression is null ? dbSet : dbSet.Where(expression);

            if (includes != null)
                foreach (var include in includes)
                    if (!string.IsNullOrEmpty(include))
                        query = query.Include(include);
            return query;
        }

        public async ValueTask<T> GetAsync(Expression<Func<T, bool>> expression, string[] includes = null)
            => await dbSet.Where(expression).FirstOrDefaultAsync();

        public async ValueTask SaveChangesAsync()
            => await dbContext.SaveChangesAsync();

        public T Update(T entity)
            => dbSet.Update(entity).Entity;
    }
}
