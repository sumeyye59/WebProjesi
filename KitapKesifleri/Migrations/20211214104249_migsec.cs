using Microsoft.EntityFrameworkCore.Migrations;

namespace KitapKesifleri.Migrations
{
    public partial class migsec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookCover",
                table: "Book",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookCover",
                table: "Book");
        }
    }
}
