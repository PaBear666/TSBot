using TSBot.Serviсes.Abstract;
using TSBot.Data.Repositories.Abstract;
using TSBot.Serviсes.Domain;
using TSBot.Data.Entity;
using AutoMapper;
using System.Threading.Tasks;

namespace TSBot.Serviсes
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new System.ArgumentNullException(nameof(userRepository));
            _mapper = mapper;
        }
        public async Task<User> AddUser(User user)
        {
            var userEntity = await _userRepository.Add(_mapper.Map<UserEntity>(user));
            return _mapper.Map<User>(userEntity);
            
        }
    }
}
