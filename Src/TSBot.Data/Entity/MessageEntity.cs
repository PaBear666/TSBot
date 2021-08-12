using TSBot.Data.Entity.Abstract;

namespace TSBot.Data.Entity
{
    public class MessageEntity : BaseEntity
    {
        public string Text { get; set; }
        public int WorkId { get; set; }
        public WorkEntity Work { get; set; }
        public int ChatId { get; set; }
        public ChatEntity Chat { get; set; }
    }
}