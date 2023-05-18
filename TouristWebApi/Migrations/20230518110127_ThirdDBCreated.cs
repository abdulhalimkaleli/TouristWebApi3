using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouristWebApi.Migrations
{
    public partial class ThirdDBCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Categories_CategoryId1",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Places_CategoryId1",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Places");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Places",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Places_CategoryId",
                table: "Places",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Categories_CategoryId",
                table: "Places",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Categories_CategoryId",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Places_CategoryId",
                table: "Places");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId1",
                table: "Places",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Places_CategoryId1",
                table: "Places",
                column: "CategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Categories_CategoryId1",
                table: "Places",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
