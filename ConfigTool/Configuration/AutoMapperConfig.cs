using AutoMapper;
using ConfigTool.Domain.Entities;
using ConfigTool.Models;

namespace ConfigTool.Configuration
{
  public class AutoMapperConfig
  {
    public static IMapper Configure()
    {
      var config = new MapperConfiguration(cfg =>
      {
        cfg.CreateMissingTypeMaps = true;
        cfg.AllowNullCollections = true;
        cfg.AllowNullDestinationValues = true;
        CreateMapping(cfg);
      });

      return config.CreateMapper();
    }

    private static void CreateMapping(IProfileExpression cfg)
    {
      cfg.CreateMap<Tattoo, TattooResponseModel>();
      cfg.CreateMap<Chlen, ChlenResponseModel>();
    }
  }
}