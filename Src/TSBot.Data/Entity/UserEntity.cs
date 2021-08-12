using TSBot.Data.Entity.Abstract;

namespace TSBot.Data.Entity
{
    public class UserEntity : BaseEntity
    {
        public string Email { get; set; }
        public long ChatTelegramId { get; set; }
        public string Token { get; set; }
        public string User_Type { get; set; }
        public string Name { get; set; }


    }
}
