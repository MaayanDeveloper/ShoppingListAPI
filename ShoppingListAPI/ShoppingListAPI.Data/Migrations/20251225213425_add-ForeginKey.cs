using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingListAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class addForeginKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserOKey",
                table: "ShopLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductIns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShopListKey",
                table: "ProductIns",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShopLists_UserOKey",
                table: "ShopLists",
                column: "UserOKey");

            migrationBuilder.CreateIndex(
                name: "IX_ProductIns_ProductId",
                table: "ProductIns",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductIns_ShopListKey",
                table: "ProductIns",
                column: "ShopListKey");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ShopLists_UserOs_UserOKey",
                table: "ShopLists",
                column: "UserOKey",
                principalTable: "UserOs",
                principalColumn: "Key",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductIns_ShopLists_ShopListKey",
                table: "ProductIns");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductIns_product_ProductId",
                table: "ProductIns");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopLists_UserOs_UserOKey",
                table: "ShopLists");

            migrationBuilder.DropIndex(
                name: "IX_ShopLists_UserOKey",
                table: "ShopLists");

            migrationBuilder.DropIndex(
                name: "IX_ProductIns_ProductId",
                table: "ProductIns");

            migrationBuilder.DropIndex(
                name: "IX_ProductIns_ShopListKey",
                table: "ProductIns");

            migrationBuilder.DropColumn(
                name: "UserOKey",
                table: "ShopLists");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductIns");

            migrationBuilder.DropColumn(
                name: "ShopListKey",
                table: "ProductIns");
        }
    }
}
