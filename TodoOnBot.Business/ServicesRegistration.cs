
using Microsoft.Extensions.DependencyInjection;
using TodoOnBot.Business.Interfaces;
using TodoOnBot.Business.Mapping;
using TodoOnBot.Business.Services;
using TodoOnBot.Data;

namespace TodoOnBot.Business
{
    public static class ServicesRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITodoService, TodoService>();
            services.AddRepositories();

            return services;
        }
    }
}