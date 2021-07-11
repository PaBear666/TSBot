using System;
using System.Collections.Generic;
using System.Text;
using TSBot.Entities.Abstract;

namespace TSBot.Entities
{
    public class UserEntity : BaseEntity, IUserEntity
    {
        public string Email { get; set; }
        public long ChatTelegramId { get; set; }
    }
}
