using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using TSBot.Data.Repositories.Abstract;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TSBot.TelegramUI.Models;

namespace TSBot.TelegramUI.Service
{
    public class ConfigureWebhook : IHostedService
    {
        private readonly BotAppSettings _botSettings;
        private readonly ILogger<ConfigureWebhook> _logger;
        private readonly IServiceProvider _service;

        public ConfigureWebhook(IConfiguration configuration, ILogger<ConfigureWebhook> logger, IServiceProvider service)
        {
            _botSettings = configuration.GetSection("BotConfiguration").Get<BotAppSettings>();
            _logger = logger;
            _service = service;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _service.CreateScope();
            var botClient = scope.ServiceProvider.GetRequiredService<ITelegramBotClient>();
            var webhookAddress = @$"{_botSettings.HostAddress}/bot/{_botSettings.BotToken}";
            _logger.LogInformation("Установлен webhook:", webhookAddress);
            await botClient.SetWebhookAsync(webhookAddress, allowedUpdates: Array.Empty<UpdateType>(), cancellationToken: cancellationToken);

        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            using var scope = _service.CreateScope();
            var botClient = scope.ServiceProvider.GetRequiredService<ITelegramBotClient>();

            _logger.LogInformation("Удален webhook");
            await botClient.DeleteWebhookAsync(cancellationToken: cancellationToken);
        }
    }
}
