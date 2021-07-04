using System;
using System.Collections.Generic;
using System.Text;

namespace TSBot.Entities.Abstract
{
    interface IUserEntity : IBaseEntity
    {
        string Email { get; set; }
        long ChatTelegramId { get; set; }
    }
}
