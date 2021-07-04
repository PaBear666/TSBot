using TSBot.Entities.Abstract;

namespace TSBot.Entities
{
    public class MessageEntity : BaseEntity
    {
        public string Text { get; set; }
        public int WorkId { get; set; }
        public WorkEntity Work { get; set; }
    }
}