using TodoOnBot.Data.Models;

namespace TodoOnBot.Telegram.Commands
{
    internal class CompleteCommand : CommandBase
    {
        public long TodoId { get; private set; }
        public CompleteCommand(long userId) : base(userId, CommandNames.Complete)
        {
        }

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