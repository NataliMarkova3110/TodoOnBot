using TodoOnBot.Telegram.Commands;
using TodoOnBot.Telegram.Commands.Handlers;
using TodoOnBot.Telegram.Context.Interfaces;
using TodoOnBot.Telegram.Services.Interfaces;

namespace TodoOnBot.Telegram.Services
{
    internal class CommandService : ICommandService
    {
        private const string DefaultMessage = "Command successfully proceed";
        private readonly CommandHandlerFactory _commandHandlerFactory;
        private readonly IConverstaionStorage _conversationStorage;

        public CommandService(CommandHandlerFactory commandHandlerFactory, IConverstaionStorage conversationStorage)
        {
            _commandHandlerFactory = commandHandlerFactory;
            _conversationStorage = conversationStorage;
        }

        public Response ProcessCommand(Command command)
        {
            var currentCommand = _conversationStorage.GetCurrent(command.UserId);
            if (currentCommand == null)
            {
                currentCommand = GetCommand(command);
                return Handle(currentCommand);
            }

            currentCommand.SetCurrentParameterValue(command.Text);
            return Handle(currentCommand);
        }

        private CommandBase GetCommand(Command command)
        {
            return command.Text switch
            {
                CommandNames.Start => StartProcessing(command),
                CommandNames.Add => AddProcessing(command),
                CommandNames.View => ViewProcessing(command),
                CommandNames.Complete => CompleteProcessing(command),
                CommandNames.Delete => DeleteProcessing(command),
                _ => new NoCommand(),
            };
        }

        private Response Handle(CommandBase commandDetails)
        {
            var commandHandler = _commandHandlerFactory.GetCommandHandler(commandDetails.CommandName);
            var response = commandHandler.Handle(commandDetails);
            if (response != null)
            {
                CleanStorage(commandDetails);
                return response;
            }

            return new Response() { Text = DefaultMessage };
        }

        private void CleanStorage(CommandBase command)
        {
            if (command.IsFullyPrepared())
            {
                _conversationStorage.DeleteCurrent(command.UserId);
            }
        }

        private StartCommand StartProcessing(Command command)
        {
            return new StartCommand(command.UserId, command.UserName);
        }

        private AddCommand AddProcessing(Command command)
        {
            var addCommand = new AddCommand(command.UserId);
            _conversationStorage.SetCurrent(command.UserId, addCommand);
            return addCommand;
        }

        private CommandBase CompleteProcessing(Command command)
        {
            var completeCommand = new CompleteCommand(command.UserId);
            _conversationStorage.SetCurrent(command.UserId, completeCommand);
            return completeCommand;
        }

        private CommandBase DeleteProcessing(Command command)
        {
            var deleteCommand = new DeleteCommand(command.UserId);
            _conversationStorage.SetCurrent(command.UserId, deleteCommand);
            return deleteCommand;
        }

        private CommandBase ViewProcessing(Command command)
        {
            return new ViewCommand(command.UserId);
        }
    }
}