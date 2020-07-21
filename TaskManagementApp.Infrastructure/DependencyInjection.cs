using Microsoft.Extensions.DependencyInjection;
using TaskManagementApp.Infrastructure.Repositories;
using VideoService.Services.Interfaces;

namespace TaskManagementApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICategoryOfWork, CategoryOfWork>();

            return services;
        }
    }
}
