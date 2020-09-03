using Microsoft.EntityFrameworkCore.Migrations;

namespace CasualShop.DAL.Migrations
{
    public partial class Init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clothes_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    ClothesBrandId = table.Column<int>(nullable: true),
                    TagId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clothes_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clothes_tbl_Brands_tbl_ClothesBrandId",
                        column: x => x.ClothesBrandId,
                        principalTable: "Brands_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clothes_tbl_Tags_tbl_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_tbl_ClothesBrandId",
                table: "Clothes_tbl",
                column: "ClothesBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_tbl_TagId",
                table: "Clothes_tbl",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clothes_tbl");

            migrationBuilder.DropTable(
                name: "Brands_tbl");

            migrationBuilder.DropTable(
                name: "Tags_tbl");
        }
    }
}
