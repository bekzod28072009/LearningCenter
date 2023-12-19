using LC.Domein.Entities.Courses;
using LC.Domein.Entities.Students;
using LC.Domein.Entities.Teachers;
using Microsoft.EntityFrameworkCore;

namespace LC.DataAcces.AppDbContext
{
    public class LearningCenterDbContext : DbContext
    {
        public LearningCenterDbContext(DbContextOptions<LearningCenterDbContext> options) : base(options)
        { }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Teacher> Teachers { get; set; }
    }
}
