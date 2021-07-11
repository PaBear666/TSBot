using System;
using System.Collections.Generic;
using System.Text;

namespace TSBot.Domain.Abstracts
{
    interface IUser
    {
        string Email { get; set; }
        long ChatTelegramId { get; set; }
    }
}
