using Telegram.Bot.Types.ReplyMarkups;
using TodoOnBot.Common.Models;
using TodoOnBot.Telegram.Services;

namespace TodoOnBot.Telegram.Commands
{
    internal class AddCommand : CommandBase
    {
        private Dictionary<string, Response> _parameterQuestions => new()
        {
            { "Name", new Response() { Text = "Please, setup name for your task:" } },
            { "DueDate", new Response() { Text = "Please, due date for your task:" } },
            { "Priority", new Response()
                {
                    Text = "Please, setup priority for your task:",
                    ReplyKeyboardMarkup = new InlineKeyboardMarkup(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData(Priority.High.ToString()),
                            InlineKeyboardButton.WithCallbackData(Priority.Medium.ToString()),
                            InlineKeyboardButton.WithCallbackData(Priority.Low.ToString())
                        }
                    }) } },
        };

        private Dictionary<string, string> _parameterValues = [];

        public AddCommand(long userId) : base(userId, CommandNames.Add)
        {
        }

        public override void SetCurrentParameterValue(string value)
        {
            var lastParameterName = _parameterQuestions.Keys.ElementAt(_parameterValues.Count);
            _parameterValues[lastParameterName] = value;
        }

        public Response GetNextParameterQuestion()
        {
            var lastParameterName = _parameterQuestions.Keys.ElementAt(_parameterValues.Count);
            return _parameterQuestions[lastParameterName];
        }

        public override bool IsFullyPrepared() => _parameterQuestions.Count == _parameterValues.Count;

        public (string name, string dateTime, string priority) GetValues()
        {
            var name = _parameterValues["Name"];
            var dueDate = _parameterValues["DueDate"];
            var priority = _parameterValues["Priority"];

            return (name, dueDate, priority);
        }
    }
}