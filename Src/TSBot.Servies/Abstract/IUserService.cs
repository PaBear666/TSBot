using System.Threading.Tasks;
using TSBot.Serviсes.Domain;

namespace TSBot.Serviсes.Abstract
{
    public interface IUserService
    {
        public Task<User> AddUser(User user);
    }
}
