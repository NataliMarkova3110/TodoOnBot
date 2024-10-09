namespace TodoOnBot.Telegram.Commands
{
    internal class CommandBase
    {
        public string CommandName { get; }
        public long UserId { get; }

        public CommandBase()
        {
        }

        public CommandBase(string commandName) : this()
        {
            CommandName = commandName;
        }

        public CommandBase(long userId, string commandName) : this(commandName)
        {
            UserId = userId;
        }

        public virtual void SetCurrentParameterValue(string value)
        {
        }

        public virtual bool IsFullyPrepared()
        {
            return true;
        }
    }
}