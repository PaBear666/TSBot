using System.Collections.Generic;

namespace TSBot.Data.Entity
{
    public class StudentEntity : UserEntity
    {
        public List<ChatEntity> Chats { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
