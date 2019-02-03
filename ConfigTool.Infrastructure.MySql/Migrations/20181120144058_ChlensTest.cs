using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConfigTool.Infrastructure.MySql.Migrations
{
    public partial class ChlensTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chlen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Owner = table.Column<string>(maxLength: 128, nullable: false),
                    Length = table.Column<int>(nullable: false),
                    IsHairy = table.Column<bool>(nullable: false),
                    Tattoo = table.Column<string>(type: "Json", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chlen", x => x.Id);
                });

            migrationBuilder.Sql(@"
                INSERT INTO chlen (Owner,Length,IsHairy) VALUES('Anton',1,1); 
                INSERT INTO chlen (Owner,Length,IsHairy) VALUES('Sasha',20,0);", true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chlen");
        }
    }
}
