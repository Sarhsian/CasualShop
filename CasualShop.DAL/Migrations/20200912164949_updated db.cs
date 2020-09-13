using Microsoft.EntityFrameworkCore.Migrations;

namespace CasualShop.DAL.Migrations
{
    public partial class updateddb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_tbl_Brands_tbl_ClothesBrandId",
                table: "Clothes_tbl");

            migrationBuilder.DropIndex(
                name: "IX_Clothes_tbl_ClothesBrandId",
                table: "Clothes_tbl");

            migrationBuilder.DropColumn(
                name: "ClothesBrandId",
                table: "Clothes_tbl");

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Clothes_tbl",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_tbl_BrandId",
                table: "Clothes_tbl",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_tbl_Brands_tbl_BrandId",
                table: "Clothes_tbl",
                column: "BrandId",
                principalTable: "Brands_tbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_tbl_Brands_tbl_BrandId",
                table: "Clothes_tbl");

            migrationBuilder.DropIndex(
                name: "IX_Clothes_tbl_BrandId",
                table: "Clothes_tbl");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Clothes_tbl");

            migrationBuilder.AddColumn<int>(
                name: "ClothesBrandId",
                table: "Clothes_tbl",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_tbl_ClothesBrandId",
                table: "Clothes_tbl",
                column: "ClothesBrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_tbl_Brands_tbl_ClothesBrandId",
                table: "Clothes_tbl",
                column: "ClothesBrandId",
                principalTable: "Brands_tbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
