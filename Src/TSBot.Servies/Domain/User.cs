using TSBot.Serviсes.Domain.Abstracts;

namespace TSBot.Serviсes.Domain
{
    public class User : IUser
    {
        public string Email { get; set; }
        public long ChatTelegramId { get; set; }
    }
}
