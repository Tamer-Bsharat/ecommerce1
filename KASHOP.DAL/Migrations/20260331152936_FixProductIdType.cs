using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KASHOP.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixProductIdType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsTranslation_Products_ProductId1",
                table: "ProductsTranslation");

            migrationBuilder.DropIndex(
                name: "IX_ProductsTranslation_ProductId1",
                table: "ProductsTranslation");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "ProductsTranslation");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductsTranslation",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsTranslation_ProductId",
                table: "ProductsTranslation",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsTranslation_Products_ProductId",
                table: "ProductsTranslation",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsTranslation_Products_ProductId",
                table: "ProductsTranslation");

            migrationBuilder.DropIndex(
                name: "IX_ProductsTranslation_ProductId",
                table: "ProductsTranslation");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "ProductsTranslation",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "ProductsTranslation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductsTranslation_ProductId1",
                table: "ProductsTranslation",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsTranslation_Products_ProductId1",
                table: "ProductsTranslation",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
