using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using TaskTacker.DataAccess;
using TaskTracker.Interfaces.Common;
using TaskTracker.Interfaces.Repositories;
using TaskTracker.Interfaces.Services;
using TaskTracker.Respositories;
using TaskTracker.Services.TaskService;

namespace TaskTracker.DependencyInjector
{
    [ExcludeFromCodeCoverage]
    public static class DependencyMapper
    {
        public static void ConfigureDependantServices(this IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>()
                .AddScoped<IDatabaseContext>(provider => provider.GetService<DatabaseContext>());
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<ITaskService, TaskService>();
        }
    }
}