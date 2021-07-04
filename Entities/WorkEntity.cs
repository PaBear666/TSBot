using TSBot.Entities.Abstract;

namespace TSBot.Entities
{
    public class WorkEntity : BaseEntity
    {
        public string Path { get; set; }
        public bool Accept { get; set; }
        public int MessageId { get; set; }
        public MessageEntity Message { get; set; }
    }
}