using System;
using System.Data.SqlClient;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ConfigTool.Infrastructure.SqlServer
{
  public class ApplicationContextDesignFactory : IDesignTimeDbContextFactory<ApplicationContext>
  {
    public ApplicationContext CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()).FullName + "/ConfigTool.App.WithMySql")
        .AddJsonFile("appsettings.json")
        .Build();

      var msb = new SqlConnectionStringBuilder(configuration.GetConnectionString("Db"));
      var options = new DbContextOptionsBuilder<ApplicationContext>()
        .UseSqlServer(msb.ToString(), b => b.MigrationsAssembly("ConfigTool.Infrastructure.SqlServer"));
      Console.WriteLine(msb.ToString());
      return new ApplicationContext(options.Options);
    }
  }
} 