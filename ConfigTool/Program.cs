using ConfigTool.Configuration;
using ConfigTool.Configuration.Logging;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ConfigTool
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseUrls("http://0.0.0.0:5000")
                .ConfigureLogging((hostingContext, logging) => logging.AddLog4Net())
                .UseStartup<Startup>()
                .CaptureStartupErrors(true);
    }
}