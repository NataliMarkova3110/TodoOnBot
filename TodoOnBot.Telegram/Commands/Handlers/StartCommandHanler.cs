using TodoOnBot.Business.Interfaces;
using TodoOnBot.Business.Models;
using TodoOnBot.Telegram.Commands.Interfaces;
using TodoOnBot.Telegram.Services;

namespace TodoOnBot.Telegram.Commands.Handlers
{
    internal class StartCommandHandler : ICommandHandler
    {
        public string CommandName { get => CommandNames.Start; }
        private readonly IUserService _userService;

        public StartCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public Response Handle(CommandBase command)
        {
            var startCommand = command as StartCommand;
            _userService.AddOrUpdate(new UserDto
            {
                UserId = startCommand.UserId,
                UserName = startCommand.UserName,
            });
            return new Response() { Text = "You can use menu to proceed some commands" };
        }
    }
}