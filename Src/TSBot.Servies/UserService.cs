using TSBot.Serviсes.Abstract;
using TSBot.Data.Repositories;
namespace TSBot.Serviсes
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new System.ArgumentNullException(nameof(userRepository));
        }
    }
}
