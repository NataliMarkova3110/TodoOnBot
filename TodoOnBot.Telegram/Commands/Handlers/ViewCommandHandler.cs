using System.Text;
using TodoOnBot.Business.Interfaces;
using TodoOnBot.Telegram.Commands.Interfaces;
using TodoOnBot.Telegram.Services;

namespace TodoOnBot.Telegram.Commands.Handlers
{
    internal class ViewCommandHandler : ICommandHandler
    {
        private readonly ITodoService _todoService;
        public string CommandName => CommandNames.View;

        public ViewCommandHandler(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public Response Handle(CommandBase command)
        {
            var tasks = _todoService.GetAllIncompleted(command.UserId).ToArray();
            if (tasks.Length == 0)
            {
                return new Response() { Text = "You don't have any tasks yet!" };
            }

            var stringBuilder = new StringBuilder();
            foreach (var task in tasks)
            {
                stringBuilder.AppendLine($"{task.TodoId}. {task.Name} ({task.DueDate})");
            }

            return new Response() { Text = stringBuilder.ToString() };
        }
    }
}