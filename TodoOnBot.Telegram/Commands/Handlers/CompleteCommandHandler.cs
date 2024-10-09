using Telegram.Bot.Types.ReplyMarkups;
using TodoOnBot.Business.Interfaces;
using TodoOnBot.Telegram.Commands.Interfaces;
using TodoOnBot.Telegram.Services;

namespace TodoOnBot.Telegram.Commands.Handlers
{
    internal class CompleteCommandHandler : ICommandHandler
    {
        private readonly ITodoService _todoService;
        public string CommandName => CommandNames.Complete;
        public CompleteCommandHandler(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public Response Handle(CommandBase command)
        {
            var completeCommand = command as CompleteCommand;
            if (completeCommand.IsFullyPrepared())
            {
                Execute(completeCommand.TodoId);
                return new Response() { Text = "Task was completed successfully!" };
            }

            return GetTasksToComplete(command.UserId);
        }

        private void Execute(long todoId)
        {
            var todoTask = _todoService.GetById(todoId);
            _todoService.Complete(todoTask);
        }

        private void Execute(Dictionary<string, string> values)
        {
            var idTask = values["Complete"];
            var todoTask = _todoService.GetById(long.Parse(idTask));

            _todoService.Complete(todoTask);
        }

        private Response GetTasksToComplete(long userId)
        {
            var userTasks = _todoService.GetAllIncompleted(userId);
            var replyMarkup = userTasks.Select(x => InlineKeyboardButton.WithCallbackData(x.Name, x.TodoId.ToString()));

            var response = new Response
            {
                Text = "Select task to be completed",
                ReplyKeyboardMarkup = new InlineKeyboardMarkup(new[] { replyMarkup })
            };
            return response;
        }
    }
}