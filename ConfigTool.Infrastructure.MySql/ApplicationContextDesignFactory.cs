using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace ConfigTool.Infrastructure.MySql
{
  public class ApplicationContextDesignFactory : IDesignTimeDbContextFactory<ApplicationContext>
  {
    public ApplicationContext CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();

      var msb = new MySqlConnectionStringBuilder(configuration.GetConnectionString("Db"))
      {
        Database = new MySqlConnectionStringBuilder(configuration.GetConnectionString("Db")).Database
      };
      var options = new DbContextOptionsBuilder<ApplicationContext>()
        .UseMySql(msb.ToString(), b => b.MigrationsAssembly("ConfigTool.Infrastructure.MySql"));
      Console.WriteLine(msb.ToString());
      return new ApplicationContext(options.Options);
    }
  }
}