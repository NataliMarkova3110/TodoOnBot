using TodoOnBot.Business.Models;

namespace TodoOnBot.Business.Interfaces
{
    public interface IUserService
    {
        public void AddOrUpdate(UserDto user);
    }
}