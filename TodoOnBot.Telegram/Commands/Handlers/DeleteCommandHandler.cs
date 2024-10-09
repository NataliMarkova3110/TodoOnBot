using Telegram.Bot.Types.ReplyMarkups;
using TodoOnBot.Business.Interfaces;
using TodoOnBot.Telegram.Commands.Interfaces;
using TodoOnBot.Telegram.Services;

namespace TodoOnBot.Telegram.Commands.Handlers
{
    internal class DeleteCommandHandler : ICommandHandler
    {
        private readonly ITodoService _todoService;
        public string CommandName => CommandNames.Delete;

        public DeleteCommandHandler(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public Response Handle(CommandBase command)
        {
            var deleteCommand = command as DeleteCommand;
            if (deleteCommand.IsFullyPrepared())
            {
                return Execute(deleteCommand.TodoId);
            }

            return PrepareCommand(command);
        }

        private Response Execute(long todoId)
        {
            _todoService.Delete(todoId);
            return new Response { Text = "Task was deleted successfully!" };
        }

        private Response PrepareCommand(CommandBase command)
        {
            var userTasks = _todoService.GetAllIncompleted(command.UserId);
            var replyMarkup = userTasks.Select(x => InlineKeyboardButton.WithCallbackData(x.Name, x.TodoId.ToString()));
            var response = new Response
            {
                Text = "Select task to be deleted",
                ReplyKeyboardMarkup = new InlineKeyboardMarkup(new[] { replyMarkup })
            };
            return response;
        }
    }
}