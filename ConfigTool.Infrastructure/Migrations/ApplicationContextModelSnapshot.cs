﻿// <auto-generated />
using ConfigTool.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConfigTool.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ConfigTool.Domain.Entities.Chlen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsHairy");

                    b.Property<int>("Length");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Tattoo")
                        .HasColumnType("Json");

                    b.HasKey("Id");

                    b.ToTable("chlen");
                });
#pragma warning restore 612, 618
        }
    }
}