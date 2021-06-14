using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationProperty.Data.Migrations
{
    public partial class UpdatePropertyNames2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StreetNumber",
                table: "Properties");

            migrationBuilder.AddColumn<string>(
                name: "HouseNumber",
                table: "Properties",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HouseNumber",
                table: "Properties");

            migrationBuilder.AddColumn<string>(
                name: "StreetNumber",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
