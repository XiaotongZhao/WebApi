using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Repository.Migrations
{
    public partial class removeTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "menus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "menus",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
