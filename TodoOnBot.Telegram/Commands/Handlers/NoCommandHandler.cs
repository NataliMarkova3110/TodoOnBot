using TodoOnBot.Telegram.Commands.Interfaces;
using TodoOnBot.Telegram.Services;

namespace TodoOnBot.Telegram.Commands.Handlers
{
    internal class NoCommandHandler : ICommandHandler
    {
        public string CommandName => string.Empty;

        public Response Handle(CommandBase command)
        {
            return new Response() { Text = "Command doesn't exist, please try again!" };
        }
    }
}