using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace ConfigTool.Infrastructure
{
  public class ApplicationContextDesignFactory : IDesignTimeDbContextFactory<ApplicationContext>
  {
    public ApplicationContext CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()).FullName + "/ConfigTool")
        .AddJsonFile("appsettings.json")
        .Build();

      var msb = new MySqlConnectionStringBuilder(configuration.GetConnectionString("Db"))
      {
        Database = new MySqlConnectionStringBuilder(configuration.GetConnectionString("Db")).Database
      };
      var options = new DbContextOptionsBuilder<ApplicationContext>().UseMySql(msb.ToString());
      Console.WriteLine(msb.ToString());
      return new ApplicationContext(options.Options);
    }
  }
}