using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TSBot.Data;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using TelegramUI.Models;
using TSBot.Data.Repositories;
using TSBot.Serviñes.Abstract;
using TSBot.Serviñes;
using TelegramUI.Service;
using Newtonsoft.Json;

namespace TSBot.TelegramUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _appSettings = configuration.GetSection("BotConfiguration").Get<BotAppSettings>();
        }

        private readonly BotAppSettings _appSettings;
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddNewtonsoftJson();
            services.AddHttpClient("TgWebhook").AddTypedClient<ITelegramBotClient>(httpClient => new TelegramBotClient(_appSettings.BotToken,httpClient));
            services.AddHostedService<ConfigureWebhook>();
            services.AddDbContext<ApplicationContext>(builder =>
                {
                    builder.UseSqlServer(Configuration.GetConnectionString("TSBotConnectionString"),b => b.MigrationsAssembly("TelegramUI"));
                });
            services.AddScoped<UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<HandleUpdateService>();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                var token = _appSettings.BotToken;
                endpoints.MapControllerRoute(name: "tgwebhook",
                                             pattern: $"bot/{token}",
                                             new { controller = "Webhook", action = "Post" });
                endpoints.MapControllers();
            });
        }
    }
}
