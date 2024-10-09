using TodoOnBot.Data.Interfaces;
using TodoOnBot.Data.Models;

namespace TodoOnBot.Data.Repository
{
    internal class UserRepository : IRepository<User>
    {
        private readonly List<User> _users;

        public UserRepository()
        {
            _users = [];
        }

        public void Add(User entity)
        {
            _users.Add(entity);
        }

        public void Delete(User entity)
        {
            _users.Remove(entity);
        }

        public List<User> GetAll()
        {
            return _users;
        }

        public User GetById(long id)
        {
            return _users.FirstOrDefault(user => user.UserId == id);
        }

        public void Update(User entity)
        {
            var existUser = GetById(entity.UserId);

            if (existUser != null)
            {
                existUser.UserName = entity.UserName;
            }
        }
    }
}