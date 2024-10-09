
using TodoOnBot.Telegram.Commands.Interfaces;

namespace TodoOnBot.Telegram.Commands.Handlers
{
    internal class CommandHandlerFactory
    {
        private IEnumerable<ICommandHandler> _handlers;

        public CommandHandlerFactory(IEnumerable<ICommandHandler> commandHandlers)
        {
            _handlers = commandHandlers;
        }

        public ICommandHandler GetCommandHandler(string command)
        {
            var commandHandler = _handlers.FirstOrDefault(x => x.CommandName == command);
            if (commandHandler == null)
            {
                return new NoCommandHandler();
            }

            return commandHandler;
        }
    }
}