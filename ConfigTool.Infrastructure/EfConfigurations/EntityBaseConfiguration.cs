using ConfigTool.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConfigTool.Infrastructure.EfConfigurations
{
  public class EntityBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : EntityBase
  {
    public void Configure(EntityTypeBuilder<T> builder)
    {
      builder.HasKey(p => p.Id);

      builder.Property(p => p.Id)
        .ValueGeneratedOnAdd();

      ConfigureNext(builder);
    }

    protected virtual void ConfigureNext(EntityTypeBuilder<T> builder)
    {
    }
  }
}