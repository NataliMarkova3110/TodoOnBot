using TodoOnBot.Business.Interfaces;
using TodoOnBot.Business.Models;
using TodoOnBot.Telegram.Commands.Interfaces;
using TodoOnBot.Telegram.Services;

namespace TodoOnBot.Telegram.Commands.Handlers
{
    internal class AddCommandHandler : ICommandHandler
    {
        private readonly ITodoService _todoService;

        public AddCommandHandler(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public string CommandName { get => CommandNames.Add; }

        public Response Handle(CommandBase command)
        {
            var addCommand = command as AddCommand;
            if (addCommand.IsFullyPrepared())
            {
                Execute(addCommand);
                return new Response() { Text = "You have added todo task" };
            }

            return addCommand.GetNextParameterQuestion();
        }

        private void Execute(AddCommand command)
        {
            var (name, dueDate, priority) = command.GetValues();
            var todo = TodoDtoFactory.Create(command.UserId, name, dueDate, priority);
            _todoService.Add(todo);
        }
    }
}