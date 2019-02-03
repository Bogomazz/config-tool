﻿// <auto-generated />

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConfigTool.Infrastructure.MySql.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20181120144058_ChlensTest")]
    partial class ChlensTest
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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