using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using TestClassConsole;

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

var host = CreateHostBuilder(args, configuration).Build();

using (var serviceScope = host.Services.CreateScope())
{
    var serviceProvider = serviceScope.ServiceProvider;

    try
    {
        ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddNLog("nlog.config");
        });

        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogInformation("Starting application...");

        var myService = serviceProvider.GetRequiredService<MyService>();
        myService.Run();

        logger.LogInformation("Application completed.");
    }
    catch (Exception ex)
    {
        var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Application stopped due to an error.");
        throw;
    }
    finally
    {
        NLog.LogManager.Shutdown();
    }
}

static IHostBuilder CreateHostBuilder(string[] args, IConfiguration configuration) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.SetMinimumLevel(LogLevel.Trace);
                builder.AddNLog(configuration);
            });

            services.AddSingleton<MyService>();
        });
