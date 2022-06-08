using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThanksCardAPI.Migrations
{
    public partial class database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goods_ThanksCards_ThnaksCardId",
                table: "Goods");

            migrationBuilder.RenameColumn(
                name: "ThnaksCardId",
                table: "Goods",
                newName: "ThanksCardId");

            migrationBuilder.RenameIndex(
                name: "IX_Goods_ThnaksCardId",
                table: "Goods",
                newName: "IX_Goods_ThanksCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goods_ThanksCards_ThanksCardId",
                table: "Goods",
                column: "ThanksCardId",
                principalTable: "ThanksCards",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goods_ThanksCards_ThanksCardId",
                table: "Goods");

            migrationBuilder.RenameColumn(
                name: "ThanksCardId",
                table: "Goods",
                newName: "ThnaksCardId");

            migrationBuilder.RenameIndex(
                name: "IX_Goods_ThanksCardId",
                table: "Goods",
                newName: "IX_Goods_ThnaksCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goods_ThanksCards_ThnaksCardId",
                table: "Goods",
                column: "ThnaksCardId",
                principalTable: "ThanksCards",
                principalColumn: "Id");
        }
    }
}
