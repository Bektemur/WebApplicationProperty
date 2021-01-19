using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationProperty.Data.Migrations
{
    public partial class AddStationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceForRent",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PriceForSale",
                table: "Properties");

            migrationBuilder.AddColumn<double>(
                name: "GeoLat",
                table: "Stations",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "GeoLong",
                table: "Stations",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "PlaceName",
                table: "Stations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StationType",
                table: "Stations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "GeoLat",
                table: "Properties",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "GeoLong",
                table: "Properties",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeoLat",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "GeoLong",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "PlaceName",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "StationType",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "GeoLat",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "GeoLong",
                table: "Properties");

            migrationBuilder.AddColumn<double>(
                name: "PriceForRent",
                table: "Properties",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PriceForSale",
                table: "Properties",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
