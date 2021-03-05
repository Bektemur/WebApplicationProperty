using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationProperty.Data.Migrations
{
    public partial class AddAddressProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Properties");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Properties",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Properties",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Properties",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Properties",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Properties",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Properties",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Properties",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubDistrict",
                table: "Properties",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Properties",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "District",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "SubDistrict",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Properties");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
