using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationProperty.Data.Migrations
{
    public partial class AddDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Improvements",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[] { 1, "Parking", 2 });

            migrationBuilder.InsertData(
                table: "TypeProperties",
                columns: new[] { "TypePropertyId", "Name" },
                values: new object[,]
                {
                    { 14, "Commercial Building" },
                    { 13, "Factory" },
                    { 12, "Business" },
                    { 11, "Retail" },
                    { 10, "Shop house" },
                    { 9, "Serviced Apartment" },
                    { 15, "Hotel / Resort" },
                    { 8, "Penthouse" },
                    { 6, "Office" },
                    { 5, "Appartment" },
                    { 4, "Condominium" },
                    { 3, "House" },
                    { 2, "Townhouse" },
                    { 1, "Unspecified" },
                    { 7, "Land" },
                    { 16, "Other Commertcial" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TypeProperties",
                keyColumn: "TypePropertyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TypeProperties",
                keyColumn: "TypePropertyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TypeProperties",
                keyColumn: "TypePropertyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TypeProperties",
                keyColumn: "TypePropertyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TypeProperties",
                keyColumn: "TypePropertyId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TypeProperties",
                keyColumn: "TypePropertyId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TypeProperties",
                keyColumn: "TypePropertyId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TypeProperties",
                keyColumn: "TypePropertyId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TypeProperties",
                keyColumn: "TypePropertyId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TypeProperties",
                keyColumn: "TypePropertyId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TypeProperties",
                keyColumn: "TypePropertyId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TypeProperties",
                keyColumn: "TypePropertyId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TypeProperties",
                keyColumn: "TypePropertyId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TypeProperties",
                keyColumn: "TypePropertyId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TypeProperties",
                keyColumn: "TypePropertyId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TypeProperties",
                keyColumn: "TypePropertyId",
                keyValue: 16);
        }
    }
}
