using System;
using System.Collections.Generic;
using System.Text;
using TSBot.Domain.Abstracts;

namespace TSBot.Domain
{
    public class User : IUser
    {
        public string Email { get; set; }
        public long ChatTelegramId { get; set; }
    }
}
