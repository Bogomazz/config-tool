﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConfigTool.Infrastructure.SqlServer.Migrations
{
    public partial class SqlServInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chlen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Owner = table.Column<string>(maxLength: 128, nullable: false),
                    Length = table.Column<int>(nullable: false),
                    IsHairy = table.Column<bool>(nullable: false),
                    Tattoo = table.Column<string>(type: "Json", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chlen", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chlen");
        }
    }
}