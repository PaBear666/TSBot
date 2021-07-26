using System;
using System.Collections.Generic;
using System.Text;

namespace TSBot.Entities
{
    public class StudentEntity : UserEntity
    {
        //public List<ChatEntity> Chats { get; set; }
        public List<TeacherEntity> Teachers { get; set; }
    }
}
