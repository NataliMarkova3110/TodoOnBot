using AutoMapper;
using TodoOnBot.Business.Interfaces;
using TodoOnBot.Business.Models;
using TodoOnBot.Data.Interfaces;
using TodoOnBot.Data.Models;

namespace TodoOnBot.Business.Services
{
    internal class TodoService : ITodoService
    {
        private readonly ITodoRepository _repository;
        private readonly IMapper _mapper;

        public TodoService(ITodoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Add(TodoDto todoDto)
        {
            var todo = _mapper.Map<Todo>(todoDto);
            _repository.Add(todo);
        }

        public void Complete(TodoDto todoDto)
        {
            var todo = _mapper.Map<Todo>(todoDto);
            todo.IsCompleted = true;

            _repository.Update(todo);
        }

        public void Delete(long todoId)
        {
            var todo = _repository.GetById(todoId);
            _repository.Delete(todo);
        }

        public TodoDto GetById(long todoId)
        {
            return _mapper.Map<TodoDto>(_repository.GetById(todoId));
        }

        public List<TodoDto> GetAll(long userId)
        {
            var allTodos = _repository.GetAll(userId);

            var todoDtos = _mapper.Map<List<TodoDto>>(allTodos);
            return todoDtos;
        }

        public List<TodoDto> GetAllIncompleted(long userId)
        {
            var allIncompleted = _repository.GetAllIncopmlete(userId);

            var todoDtos = _mapper.Map<List<TodoDto>>(allIncompleted);
            return todoDtos;
        }
    }
}