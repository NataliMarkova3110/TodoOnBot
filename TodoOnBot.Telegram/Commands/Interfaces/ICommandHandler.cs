using TodoOnBot.Telegram.Services;

namespace TodoOnBot.Telegram.Commands.Interfaces
{
    internal interface ICommandHandler
    {
        string CommandName { get; }
        Response Handle(CommandBase command);
    }
}