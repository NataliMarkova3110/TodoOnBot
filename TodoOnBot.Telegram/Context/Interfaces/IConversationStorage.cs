using TodoOnBot.Telegram.Commands;

namespace TodoOnBot.Telegram.Context.Interfaces
{
    internal interface IConverstaionStorage
    {
        void DeleteCurrent(long userId);
        void SetCurrent(long userId, CommandBase currentCommend);
        CommandBase GetCurrent(long userId);
    }
}