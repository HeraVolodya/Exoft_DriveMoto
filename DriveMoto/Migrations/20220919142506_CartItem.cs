using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriveMoto.Migrations
{
    /// <inheritdoc />
    public partial class CartItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_AspNetUsers_Email",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "CartItems",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_Email",
                table: "CartItems",
                newName: "IX_CartItems_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_AspNetUsers_UserId",
                table: "CartItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_AspNetUsers_UserId",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CartItems",
                newName: "Email");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_UserId",
                table: "CartItems",
                newName: "IX_CartItems_Email");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_AspNetUsers_Email",
                table: "CartItems",
                column: "Email",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
