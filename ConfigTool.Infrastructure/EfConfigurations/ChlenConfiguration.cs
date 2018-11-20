using ConfigTool.Domain.Entities;
using ConfigTool.Infrastructure.EfConfigurations.ValueConverters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConfigTool.Infrastructure.EfConfigurations
{
  public class ChlenConfiguration : EntityBaseConfiguration<Chlen>
  {
    protected override void ConfigureNext(EntityTypeBuilder<Chlen> builder)
    {
      builder.ToTable("chlen");

      builder.Property(p => p.Owner)
        .IsRequired()
        .HasMaxLength(128);

      builder.Property(p => p.Length)
        .IsRequired();

      builder.Property(p => p.IsHairy)
        .IsRequired();

      builder.Property(p => p.Tattoo)
        .IsRequired(false)
        .HasConversion(new JsonValueConverter<Tattoo>())
        .HasColumnType("Json");

      base.ConfigureNext(builder);
    }
  }
}