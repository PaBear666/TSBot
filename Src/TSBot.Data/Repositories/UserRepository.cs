﻿using System.Threading.Tasks;
using TSBot.Data.Repositories.Abstract;
using TSBot.Data.Entity;

namespace TSBot.Data.Repositories
{
    public class UserRepository : Repository<UserEntity>, IUserRepository
    {
        public UserRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }

        public override Task<long> GetId(UserEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}