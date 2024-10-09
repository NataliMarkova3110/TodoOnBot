using TodoOnBot.Data.Models;

namespace TodoOnBot.Data.Interfaces
{
    public interface ITodoRepository : IRepository<Todo>
    {
        List<Todo> GetAll(long userId);
        List<Todo> GetAllIncopmlete(long userId);
    }
}