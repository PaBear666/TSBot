﻿using System;
using System.Collections.Generic;
using System.Text;
using TSBot.Entity.Abstract;

namespace TSBot.Entity
{
    public class ChatEntity : BaseEntity
    {
        public int TeacherId { get; set; }
        public TeacherEntity Teacher { get; set; }
        public int StudentId { get; set; }
        public StudentEntity Student { get; set; }
        public List<MessageEntity> Messages { get; set; }
    }
}
