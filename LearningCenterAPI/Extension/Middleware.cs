using LC.DataAcces.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace LearningCenterAPI.Extension
{
    public static class Middleware
    {
        public static void AddDBConTextes(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LearningCenterDbContext>(options =>
                 options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
