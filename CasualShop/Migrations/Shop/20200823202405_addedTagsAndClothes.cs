using Microsoft.EntityFrameworkCore.Migrations;

namespace CasualShop.Migrations.Shop
{
    public partial class addedTagsAndClothes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.RenameTable(
                name: "Brands",
                newName: "Brands_tbl");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands_tbl",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands_tbl",
                table: "Brands_tbl",
                column: "Id");

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
                    Description = table.Column<string>(nullable: true)
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
                name: "Tags_tbl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands_tbl",
                table: "Brands_tbl");

            migrationBuilder.RenameTable(
                name: "Brands_tbl",
                newName: "Brands");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "Id");
        }
    }
}
