using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingListAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class addForeginKeynew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductIns_ShopLists_ShopListKey",
                table: "ProductIns");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductIns_product_ProductId",
                table: "ProductIns");

            migrationBuilder.DropIndex(
                name: "IX_ProductIns_ProductId",
                table: "ProductIns");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductIns");

            migrationBuilder.AlterColumn<int>(
                name: "ShopListKey",
                table: "ProductIns",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductIns_ShopLists_ShopListKey",
                table: "ProductIns",
                column: "ShopListKey",
                principalTable: "ShopLists",
                principalColumn: "Key",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductIns_ShopLists_ShopListKey",
                table: "ProductIns");

            migrationBuilder.AlterColumn<int>(
                name: "ShopListKey",
                table: "ProductIns",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductIns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductIns_ProductId",
                table: "ProductIns",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductIns_ShopLists_ShopListKey",
                table: "ProductIns",
                column: "ShopListKey",
                principalTable: "ShopLists",
                principalColumn: "Key");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductIns_product_ProductId",
                table: "ProductIns",
                column: "ProductId",
                principalTable: "product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
