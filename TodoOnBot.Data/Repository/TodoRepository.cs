using TodoOnBot.Data.Interfaces;
using TodoOnBot.Data.Models;

namespace TodoOnBot.Data.Repository
{
    internal class TodoRepository : ITodoRepository
    {
        private readonly List<Todo> _toDoList;

        public TodoRepository()
        {
            _toDoList = [];
        }

        public List<Todo> GetAll()
        {
            return _toDoList;
        }

        public Todo GetById(long id)
        {
            return _toDoList.FirstOrDefault(todo => todo.TodoId == id);
        }

        public void Add(Todo entity)
        {
            var lastId = _toDoList.LastOrDefault();
            var id = lastId == null ? 1 : lastId.TodoId++;
            entity.TodoId = id;

            _toDoList.Add(entity);
        }

        public void Update(Todo entity)
        {
            var todo = GetById(entity.TodoId);

            if (todo != null)
            {
                todo.Priority = entity.Priority;
                todo.DueDate = entity.DueDate;
                todo.IsCompleted = entity.IsCompleted;
            }
        }

        public void Delete(Todo entity)
        {
            _toDoList.Remove(entity);
        }

        public List<Todo> GetAll(long userId)
        {
            return _toDoList.Where(x => x.UserId == userId && x.DueDate.Date == DateTime.Today).ToList();
        }

        public List<Todo> GetAllIncopmlete(long userId)
        {
            return _toDoList.Where(x => x.UserId == userId && !x.IsCompleted && x.DueDate.Date == DateTime.Today).ToList();
        }
    }
}