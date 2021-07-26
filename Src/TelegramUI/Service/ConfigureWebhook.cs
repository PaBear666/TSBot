
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using TelegramUI.Models;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramUI.Service
{
    public class ConfigureWebhook : IHostedService
    {
        private readonly BotAppSettings _appSettings;
        private readonly ILogger<ConfigureWebhook> _logger;
        private readonly IServiceProvider _service;

        public ConfigureWebhook(IConfiguration appSettings, ILogger<ConfigureWebhook> logger, IServiceProvider service)
        {
            _appSettings = appSettings.GetSection("BotConfiguration").Get<BotAppSettings>();
            _logger = logger;
            _service = service;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _service.CreateScope();
            var botClient = scope.ServiceProvider.GetRequiredService<ITelegramBotClient>();
            var webhookAddress = @$"{_appSettings.HostAddress}/bot/{_appSettings.BotToken}";
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
