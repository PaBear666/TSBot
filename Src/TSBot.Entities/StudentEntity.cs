﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TSBot.Entity
{
    public class StudentEntity : UserEntity
    {
        public List<ChatEntity> Chats { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
