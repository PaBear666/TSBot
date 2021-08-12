using System.Collections.Generic;

namespace TSBot.Serviсes.Domain
{
    public class Chat
    {
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}