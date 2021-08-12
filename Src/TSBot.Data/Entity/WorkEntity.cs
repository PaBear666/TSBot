using TSBot.Data.Entity.Abstract;

namespace TSBot.Data.Entity
{
    public class WorkEntity : BaseEntity
    {
        public string Path { get; set; }
        public bool Accept { get; set; }
        public int MessageId { get; set; }
        public MessageEntity Message { get; set; }
    }
}