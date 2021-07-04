using System;
using System.Collections.Generic;
using System.Text;

namespace TSBot.Entities
{
    public class TeacherEntity : UserEntity
    {
        public List<GroupEntity> Groups { get; set; }
    }
}
