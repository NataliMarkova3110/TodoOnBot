
using Microsoft.Extensions.DependencyInjection;
using TodoOnBot.Data.Interfaces;
using TodoOnBot.Data.Models;
using TodoOnBot.Data.Repository;

namespace TodoOnBot.Data
{
    public static class ServicesRegistration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<ITodoRepository, TodoRepository>();

            return services;
        }
    }
}