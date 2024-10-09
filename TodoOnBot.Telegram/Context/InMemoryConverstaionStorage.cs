using TodoOnBot.Telegram.Commands;
using TodoOnBot.Telegram.Context.Interfaces;

namespace TodoOnBot.Telegram.Context
{
    internal class InMemoryConverstaionStorage : IConverstaionStorage
    {
        private readonly Dictionary<long, CommandBase> _storage;

        public InMemoryConverstaionStorage()
        {
            _storage = [];
        }

        public void DeleteCurrent(long userId)
        {
            _storage.Remove(userId);
        }

        public CommandBase GetCurrent(long userId)
        {
            if (_storage.TryGetValue(userId, out CommandBase? value))
            {
                return value;
            }

            return null;
        }

        public void SetCurrent(long userId, CommandBase context)
        {
            _storage[userId] = context;
        }
    }
}