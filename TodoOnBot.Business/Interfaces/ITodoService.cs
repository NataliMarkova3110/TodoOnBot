using TodoOnBot.Business.Models;

namespace TodoOnBot.Business.Interfaces
{
    public interface ITodoService
    {
        public TodoDto GetById(long todoId);
        public List<TodoDto> GetAll(long userId);
        public List<TodoDto> GetAllIncompleted(long userId);
        public void Add(TodoDto todo);
        public void Complete(TodoDto todo);
        public void Delete(long todoId);
    }
}