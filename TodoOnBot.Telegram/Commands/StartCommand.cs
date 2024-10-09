namespace TodoOnBot.Telegram.Commands
{
    internal class StartCommand : CommandBase
    {
        public string UserName { get; set; }

        public StartCommand(long userId, string userName) : base(userId, CommandNames.Start)
        {
            UserName = userName;
        }
    }
}