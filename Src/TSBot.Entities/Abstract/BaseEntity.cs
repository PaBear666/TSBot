using System;
using System.Collections.Generic;
using System.Text;

namespace TSBot.Entities.Abstract
{
    abstract public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
