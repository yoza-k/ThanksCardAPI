using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ThanksCardAPI.Migrations
{
    public partial class AddThanksCardTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThanksCards_Users_FromId",
                table: "ThanksCards");

            migrationBuilder.DropForeignKey(
                name: "FK_ThanksCards_Users_ToId",
                table: "ThanksCards");

            migrationBuilder.AlterColumn<long>(
                name: "ToId",
                table: "ThanksCards",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "FromId",
                table: "ThanksCards",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThanksCardTag",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ThanksCardId = table.Column<long>(nullable: false),
                    TagId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanksCardTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThanksCardTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThanksCardTag_ThanksCards_ThanksCardId",
                        column: x => x.ThanksCardId,
                        principalTable: "ThanksCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThanksCardTag_TagId",
                table: "ThanksCardTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_ThanksCardTag_ThanksCardId",
                table: "ThanksCardTag",
                column: "ThanksCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_ThanksCards_Users_FromId",
                table: "ThanksCards",
                column: "FromId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThanksCards_Users_ToId",
                table: "ThanksCards",
                column: "ToId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThanksCards_Users_FromId",
                table: "ThanksCards");

            migrationBuilder.DropForeignKey(
                name: "FK_ThanksCards_Users_ToId",
                table: "ThanksCards");

            migrationBuilder.DropTable(
                name: "ThanksCardTag");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.AlterColumn<long>(
                name: "ToId",
                table: "ThanksCards",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "FromId",
                table: "ThanksCards",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_ThanksCards_Users_FromId",
                table: "ThanksCards",
                column: "FromId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThanksCards_Users_ToId",
                table: "ThanksCards",
                column: "ToId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
