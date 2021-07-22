using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramUI.Models.Commands;
namespace TelegramUI.Models
{
    public static class Bot
    {
        private static TelegramBotClient _client;
        private static List<Command> _commandsList;
        public static IReadOnlyList<Command> Commands { get => _commandsList.AsReadOnly(); }
        public static async Task<TelegramBotClient> Get()
        {
            if(_client != null)
            {
                return _client;
            }
            _commandsList = new List<Command>
            {
                new HelloCommand("Hello")
            };
            _client = new TelegramBotClient(AppSettings.Key);
            await _client.SetWebhookAsync("");
            return _client;
            

        }
    }
}
