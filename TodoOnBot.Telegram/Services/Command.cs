namespace TodoOnBot.Telegram.Services
{
    internal class Command
    {
        public long UserId { get; set; }

        public string UserName { get; set; }

        public string Text { get; set; }
    }
}