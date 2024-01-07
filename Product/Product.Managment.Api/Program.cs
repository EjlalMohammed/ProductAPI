
namespace Product.Managment.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using var  scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();  
            ILogger logger = loggerFactory.CreateLogger("app");
            host.Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] arge)
            => Host.CreateDefaultBuilder(arge)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                //logging.AddLog4Net("log4net.config");
            });
    }
}
