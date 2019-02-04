using ConfigTool.Api.Configuration;
using ConfigTool.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConfigTool.App.PostgreSql
{
  public class Startup : CommonStartup
  {
    public Startup(IConfiguration configuration) : base(configuration)
    {
    }

    public override void ConfigureServices(IServiceCollection services)
    {
      base.ConfigureServices(services);

      services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(Configuration.GetConnectionString("Db")));
    }
  }
}