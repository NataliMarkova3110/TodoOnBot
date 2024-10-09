using Telegram.Bot.Types.ReplyMarkups;

namespace TodoOnBot.Telegram.Services
{
    internal class Response
    {
        public string Text { get; set; }
        public InlineKeyboardMarkup ReplyKeyboardMarkup { get; set; }
    }
}