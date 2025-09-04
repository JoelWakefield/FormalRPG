using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormalRPG.Migrations
{
    /// <inheritdoc />
    public partial class FixingItemTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RpgOwnedItems_Items_ItemId",
                table: "RpgOwnedItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "RpgItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RpgItems",
                table: "RpgItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RpgOwnedItems_RpgItems_ItemId",
                table: "RpgOwnedItems",
                column: "ItemId",
                principalTable: "RpgItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RpgOwnedItems_RpgItems_ItemId",
                table: "RpgOwnedItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RpgItems",
                table: "RpgItems");

            migrationBuilder.RenameTable(
                name: "RpgItems",
                newName: "Items");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RpgOwnedItems_Items_ItemId",
                table: "RpgOwnedItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
