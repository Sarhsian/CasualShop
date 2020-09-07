using Microsoft.EntityFrameworkCore.Migrations;

namespace CasualShop.DAL.Migrations
{
    public partial class updatedbasket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Baskets_tbl");

            migrationBuilder.AddColumn<string>(
                name: "CurrentUser",
                table: "Baskets_tbl",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentUser",
                table: "Baskets_tbl");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Baskets_tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
