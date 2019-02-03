using System.Threading.Tasks;
using ConfigTool.Api.Configuration;
using ConfigTool.Api.Configuration.Logging;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ConfigTool.Api
{
    public static class ProgramStart
    {
        public static Task RunAsync<TStartup>(string[] args) where TStartup : CommonStartup
        {
            return CreateWebHostBuilder<TStartup>(args).Build().RunAsync();
        }

        private static IWebHostBuilder CreateWebHostBuilder<TStartup>(string[] args)
            where TStartup : class =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseUrls("http://localhost:5000")
                .ConfigureLogging((hostingContext, logging) => logging.AddLog4Net())
                .UseStartup<TStartup>()
                .CaptureStartupErrors(true);
    }
}