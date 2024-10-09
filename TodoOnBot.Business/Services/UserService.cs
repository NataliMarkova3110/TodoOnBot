using AutoMapper;
using TodoOnBot.Business.Interfaces;
using TodoOnBot.Business.Models;
using TodoOnBot.Data.Interfaces;
using TodoOnBot.Data.Models;

namespace TodoOnBot.Business.Services
{
    internal class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void AddOrUpdate(UserDto userDto)
        {
            var existUser = _repository.GetById(userDto.UserId);
            var user = _mapper.Map<User>(userDto);

            if (existUser == null)
            {
                _repository.Add(user);
                return;
            }

            _repository.Update(user);
        }
    }
}