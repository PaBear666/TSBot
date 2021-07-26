using TSBot.Entities;

namespace TSBot.Data.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationContext _applicationContext;
        private readonly EFGenericRepository<UserEntity> _eFGeneric;
        public UserRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
            _eFGeneric = new EFGenericRepository<UserEntity>(applicationContext);
        }
    }
}
