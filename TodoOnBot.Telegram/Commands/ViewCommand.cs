namespace TodoOnBot.Telegram.Commands.Handlers
{
    internal class ViewCommand : CommandBase
    {
        public ViewCommand(long userId) : base(userId, CommandNames.View)
        { }
    }
}