using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationProperty.Data.Migrations
{
    public partial class addprovince : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Province_Stations_StationId",
                table: "Province");

            migrationBuilder.AlterColumn<int>(
                name: "StationId",
                table: "Province",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Province_Stations_StationId",
                table: "Province",
                column: "StationId",
                principalTable: "Stations",
                principalColumn: "StationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Province_Stations_StationId",
                table: "Province");

            migrationBuilder.AlterColumn<int>(
                name: "StationId",
                table: "Province",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Province_Stations_StationId",
                table: "Province",
                column: "StationId",
                principalTable: "Stations",
                principalColumn: "StationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
