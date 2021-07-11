using System;
using System.Collections.Generic;
using System.Text;

namespace TSBot.Domain
{
    public class Student : User
    {
        public List<Chat> Chats { get; set; }

    }
}
