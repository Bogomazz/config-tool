using System;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ConfigTool.Infrastructure.SqlServer
{
  public class ApplicationContextDesignFactory : IDesignTimeDbContextFactory<ApplicationContext>
  {
    private const string DefaultConnString = "Data Source=cftool.db";

    public ApplicationContext CreateDbContext(string[] args)
    {
      if (!File.Exists("appsettings.json"))
      {
        return TerminalMigrationsWorkaround();
      }

      IConfigurationRoot configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();

      var msb = new SqlConnectionStringBuilder(configuration.GetConnectionString("Db"));
      var options = new DbContextOptionsBuilder<ApplicationContext>()
        .UseSqlServer(msb.ToString(), b => b.MigrationsAssembly("ConfigTool.Infrastructure.SqlServer"));
      Console.WriteLine(msb.ToString());
      return new ApplicationContext(options.Options);
    }

    private static ApplicationContext TerminalMigrationsWorkaround()
    {
      var options = new DbContextOptionsBuilder<ApplicationContext>()
        .UseSqlServer(DefaultConnString, b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name));
      return new ApplicationContext(options.Options);
    }
  }
} 