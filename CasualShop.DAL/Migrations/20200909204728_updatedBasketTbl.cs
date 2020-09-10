using Microsoft.EntityFrameworkCore.Migrations;

namespace CasualShop.DAL.Migrations
{
    public partial class updatedBasketTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_tbl_Clothes_tbl_BasketClothesId",
                table: "Baskets_tbl");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_tbl_BasketClothesId",
                table: "Baskets_tbl");

            migrationBuilder.AlterColumn<int>(
                name: "BasketClothesId",
                table: "Baskets_tbl",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "BasketClothesId",
                table: "Baskets_tbl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_tbl_BasketClothesId",
                table: "Baskets_tbl",
                column: "BasketClothesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_tbl_Clothes_tbl_BasketClothesId",
                table: "Baskets_tbl",
                column: "BasketClothesId",
                principalTable: "Clothes_tbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
