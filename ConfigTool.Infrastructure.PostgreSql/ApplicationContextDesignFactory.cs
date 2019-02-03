using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace ConfigTool.Infrastructure.PostgreSql
{
  public class ApplicationContextDesignFactory : IDesignTimeDbContextFactory<ApplicationContext>
  {
    public ApplicationContext CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();

      var msb = new NpgsqlConnectionStringBuilder(configuration.GetConnectionString("Db"))
      {
        Database = new NpgsqlConnectionStringBuilder(configuration.GetConnectionString("Db")).Database
      };
      var options = new DbContextOptionsBuilder<ApplicationContext>()
        .UseNpgsql(msb.ToString(), b => b.MigrationsAssembly("ConfigTool.Infrastructure.PostgreSql"));
      Console.WriteLine(msb.ToString());
      return new ApplicationContext(options.Options);
    }
  }
}