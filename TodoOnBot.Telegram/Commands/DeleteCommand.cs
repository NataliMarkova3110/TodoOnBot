namespace TodoOnBot.Telegram.Commands
{
    internal class DeleteCommand : CommandBase
    {
        public long TodoId { get; set; }

        public DeleteCommand(long userId) : base(userId, CommandNames.Delete)
        { }

        public override void SetCurrentParameterValue(string value)
        {
            TodoId = long.Parse(value);
        }

        public override bool IsFullyPrepared()
        {
            return TodoId != 0;
        }
    }
}