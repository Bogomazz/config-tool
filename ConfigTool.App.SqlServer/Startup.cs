using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigTool.Api.Configuration;
using ConfigTool.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ConfigTool.App.SqlServer
{
  public class Startup : CommonStartup
  {
    public Startup(IConfiguration configuration) : base(configuration)
    {
    }

    public override void ConfigureServices(IServiceCollection services)
    {
      base.ConfigureServices(services);

      services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Db")));
    }
  }
}