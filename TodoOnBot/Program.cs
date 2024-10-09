using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using TodoOnBot.Business;
using TodoOnBot.Telegram;

var hostBuilder = new HostBuilder()
    .ConfigureAppConfiguration(config =>
    {
        config.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true);
    })
    .ConfigureServices(services =>
    {
        services.AddBusinessServices();
        services.AddBotServices();
    })
    .UseConsoleLifetime();

await hostBuilder.RunConsoleAsync();



