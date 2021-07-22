
using Telegram.Bot.Types;
using Telegram.Bot;

namespace TelegramUI.Models.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; }

        public abstract void Execute(Message message,TelegramBotClient telegramBotClient);

        public bool Contains(string command)
        {
            return command.Contains(Name) && command.Contains(AppSettings.Name);
        }
    }
}
