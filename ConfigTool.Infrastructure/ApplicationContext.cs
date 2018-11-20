using ConfigTool.Domain.Entities;
using ConfigTool.Infrastructure.EfConfigurations;
using Microsoft.EntityFrameworkCore;

namespace ConfigTool.Infrastructure
{
  public class ApplicationContext : DbContext
  {
    public ApplicationContext(DbContextOptions opt) : base(opt)
    {
    }

    public DbSet<Chlen> Chlens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new ChlenConfiguration());

      base.OnModelCreating(modelBuilder);
    }
  }
}