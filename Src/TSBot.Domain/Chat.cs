using System.Collections;
using System.Collections.Generic;

namespace TSBot.Domain
{
    public class Chat
    {
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}