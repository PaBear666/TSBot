using System;
using System.Collections.Generic;
using System.Text;

namespace TSBot.Domain
{
    public class Teacher
    {
        public ICollection<Group> Groups { get; set; }
    }
}
