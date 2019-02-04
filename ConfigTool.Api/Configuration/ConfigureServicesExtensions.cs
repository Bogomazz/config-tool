using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace ConfigTool.Api.Configuration
{
  public static class ConfigureServicesExtensions
  {
    public static IMvcCoreBuilder AddWebApi(this IServiceCollection services)
    {
      return services.AddMvcCore().AddAuthorization().AddFormatterMappings().AddJsonFormatters().AddCors().AddApiExplorer();
    }

    public static IMvcCoreBuilder AddControllers(this IMvcCoreBuilder mvcCoreBuilder)
    {
      var controllersAssembly = Assembly.Load("ConfigTool.Api");
      return mvcCoreBuilder.AddApplicationPart(controllersAssembly).AddControllersAsServices();
    }
  }
}