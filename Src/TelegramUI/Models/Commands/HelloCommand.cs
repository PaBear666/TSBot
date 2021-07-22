using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramUI.Models.Commands
{
    public class HelloCommand : Command
    {
        public HelloCommand(string name)
        {
            Name = name;
        }
        public override string Name { get ;}

        public override async void Execute(Message message, TelegramBotClient telegramBotClient)
        {
            long chatId = message.Chat.Id;
            int messageId = message.MessageId;

            await telegramBotClient.SendTextMessageAsync(chatId, "Hello", replyToMessageId: messageId);
        }
    }
}
