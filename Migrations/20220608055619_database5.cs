using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThanksCardAPI.Migrations
{
    public partial class database5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goods_ThanksCards_ThanksCardId",
                table: "Goods");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "Goods");

            migrationBuilder.AlterColumn<long>(
                name: "ThanksCardId",
                table: "Goods",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Goods_ThanksCards_ThanksCardId",
                table: "Goods",
                column: "ThanksCardId",
                principalTable: "ThanksCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goods_ThanksCards_ThanksCardId",
                table: "Goods");

            migrationBuilder.AlterColumn<long>(
                name: "ThanksCardId",
                table: "Goods",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "CardId",
                table: "Goods",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_Goods_ThanksCards_ThanksCardId",
                table: "Goods",
                column: "ThanksCardId",
                principalTable: "ThanksCards",
                principalColumn: "Id");
        }
    }
}
