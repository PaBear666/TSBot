using System.Collections.Generic;

namespace TSBot.Domain
{
    public class Group
    {
        public Teacher Teacher { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Chat> Chats { get; set; }
    }
}