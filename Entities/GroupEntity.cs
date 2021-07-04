using System.Collections.Generic;
using TSBot.Entities.Abstract;

namespace TSBot.Entities
{
    public class GroupEntity : BaseEntity
    {
        public string Number { get; set; }
        public int TeacherId { get; set; }
        public TeacherEntity Teacher { get; set; }
        public List<ChatEntity> Chats { get; set; }

    }
}