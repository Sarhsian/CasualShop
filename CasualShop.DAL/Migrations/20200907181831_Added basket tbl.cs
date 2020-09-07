using Microsoft.EntityFrameworkCore.Migrations;

namespace CasualShop.DAL.Migrations
{
    public partial class Addedbaskettbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Baskets_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    BasketClothesId = table.Column<int>(nullable: true),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Baskets_tbl_Clothes_tbl_BasketClothesId",
                        column: x => x.BasketClothesId,
                        principalTable: "Clothes_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_tbl_BasketClothesId",
                table: "Baskets_tbl",
                column: "BasketClothesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Baskets_tbl");
        }
    }
}
