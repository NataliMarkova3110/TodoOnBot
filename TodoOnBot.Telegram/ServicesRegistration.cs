using Microsoft.Extensions.DependencyInjection;
using TodoOnBot.Telegram.Commands;
using TodoOnBot.Telegram.Commands.Handlers;
using TodoOnBot.Telegram.Commands.Interfaces;
using TodoOnBot.Telegram.Context;
using TodoOnBot.Telegram.Context.Interfaces;
using TodoOnBot.Telegram.Mapping;
using TodoOnBot.Telegram.Services;
using TodoOnBot.Telegram.Services.Interfaces;

namespace TodoOnBot.Telegram
{
    public static class ServicesRegistration
    {
        public static IServiceCollection AddBotServices(this IServiceCollection services)
        {
            services.AddHostedService<TelegramClient>();
            services.AddScoped<ICommandService, CommandService>();
            services.AddSingleton<CommandHandlerFactory>();
            services.AddScoped<ICommandHandler, AddCommandHandler>();
            services.AddScoped<ICommandHandler, StartCommandHandler>();
            services.AddScoped<ICommandHandler, ViewCommandHandler>();
            services.AddScoped<ICommandHandler, CompleteCommandHandler>();
            services.AddScoped<ICommandHandler, DeleteCommandHandler>();
            services.AddSingleton<IConverstaionStorage, InMemoryConverstaionStorage>();
            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }
    }
}