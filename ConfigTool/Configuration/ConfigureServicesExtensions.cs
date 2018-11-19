using Microsoft.Extensions.DependencyInjection;

namespace ConfigTool.Configuration
{
  public static class ConfigureServicesExtensions
  {
    public static IMvcCoreBuilder AddWebApi(this IServiceCollection services)
    {
      return services.AddMvcCore().AddAuthorization().AddFormatterMappings().AddJsonFormatters().AddCors().AddApiExplorer();
    }
  }
}