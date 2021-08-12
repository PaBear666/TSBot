using TSBot.Data;
using TSBot.Data.Repositories;
using TSBot.Serviñes.Abstract;
using TSBot.Serviñes;
using TSBot.TelegramUI.Models;
using TSBot.TelegramUI.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;

namespace TSBot.TelegramUI
{
    public class Startup
    {
        private readonly BotAppSettings _appSettings;
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _appSettings = configuration.GetSection("BotConfiguration").Get<BotAppSettings>();
        }   

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddControllers().AddNewtonsoftJson();
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<ServiceAutoMapperProfile>();
            });
            services.AddHttpClient("TgWebhook").AddTypedClient<ITelegramBotClient>(httpClient => new TelegramBotClient(_appSettings.BotToken,httpClient));
            services.AddHostedService<ConfigureWebhook>();
            services.AddDbContext<ApplicationContext>(builder =>
                {
                    builder.UseSqlServer(Configuration.GetConnectionString("TSBotConnectionString"),b => b.MigrationsAssembly("TelegramUI"));
                });
            services.AddScoped<UserRepository>();
            //services.AddScoped<IuserService,UserService>();
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
