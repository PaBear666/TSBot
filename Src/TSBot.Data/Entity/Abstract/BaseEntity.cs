using System;


namespace TSBot.Data.Entity.Abstract
{
    abstract public class BaseEntity
    {
        
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
