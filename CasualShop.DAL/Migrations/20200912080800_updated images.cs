using Microsoft.EntityFrameworkCore.Migrations;

namespace CasualShop.DAL.Migrations
{
    public partial class updatedimages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Clothes_tbl");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Clothes_tbl",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_tbl_ImageId",
                table: "Clothes_tbl",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_tbl_Images_tbl_ImageId",
                table: "Clothes_tbl",
                column: "ImageId",
                principalTable: "Images_tbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_tbl_Images_tbl_ImageId",
                table: "Clothes_tbl");

            migrationBuilder.DropIndex(
                name: "IX_Clothes_tbl_ImageId",
                table: "Clothes_tbl");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Clothes_tbl");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Clothes_tbl",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
