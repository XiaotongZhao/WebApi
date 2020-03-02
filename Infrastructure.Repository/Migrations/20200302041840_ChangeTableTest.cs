using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Repository.Migrations
{
    public partial class ChangeTableTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "menus",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "menus");
        }
    }
}
