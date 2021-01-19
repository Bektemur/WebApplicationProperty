using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationProperty.Data.Migrations
{
    public partial class AddDefaultImprovments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Improvements",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[,]
                {
                    { 2, "TV", 2 },
                    { 59, "Low Floor", 6 },
                    { 58, "High Floor", 6 },
                    { 57, "Company Registration", 6 },
                    { 56, "Badminton Court", 6 },
                    { 55, "Wheelchair accessible", 6 },
                    { 54, "Mini Market", 7 },
                    { 53, "Mini Market", 7 },
                    { 60, "Scenic View", 6 },
                    { 52, "Cleaning service", 7 },
                    { 50, "Golf Simulator", 7 },
                    { 49, "Public water meter", 7 },
                    { 48, "Shopping Mall", 7 },
                    { 47, "Goverment electricity meter", 7 },
                    { 46, "Stove", 4 },
                    { 45, "Fan", 4 },
                    { 44, "Private Pool", 4 },
                    { 51, "Co-Working Space", 7 },
                    { 43, "Cooking gas", 4 },
                    { 61, "BBQ Area", 6 },
                    { 63, "Pool View", 6 },
                    { 79, "Renovated", 1 },
                    { 78, "Needs renovation", 1 },
                    { 77, "Fully Furnished", 1 },
                    { 76, "Partially Furnished", 1 },
                    { 75, "Penthouse", 6 },
                    { 74, "Maid's Room", 6 },
                    { 73, "Lake View", 6 },
                    { 62, "New Project", 6 },
                    { 72, "City View", 6 },
                    { 70, "Rent Guarantee", 6 },
                    { 69, "Park View", 6 },
                    { 68, "Luxury", 6 },
                    { 67, "Jogging Track", 6 },
                    { 66, "Shuttle service", 6 },
                    { 65, "Allows Pets", 6 },
                    { 64, "Sea View", 6 },
                    { 71, "Allow Short-term", 6 },
                    { 42, "Oven", 4 },
                    { 41, "Bathtub", 4 },
                    { 40, "Air Conditioning", 4 },
                    { 18, "Lounge", 5 },
                    { 17, "Common jacuzzi", 5 },
                    { 16, "Function Room", 5 },
                    { 15, "Common garden", 5 },
                    { 14, "Water Heater", 2 },
                    { 13, "Closed kitchen", 2 },
                    { 12, "Cooker Hob & Hood", 2 },
                    { 19, "Restaurant", 5 },
                    { 11, "Open kitchen", 2 },
                    { 9, "Private garden", 2 },
                    { 8, "Drying Machine", 2 },
                    { 7, "Internet", 2 },
                    { 6, "Balcony", 2 },
                    { 5, "Kitchen", 2 },
                    { 4, "Washing Machine", 2 },
                    { 3, "Refrigerator", 2 },
                    { 10, "Roof Terrace", 2 },
                    { 20, "Building security", 5 },
                    { 21, "Garage", 5 },
                    { 22, "Onsen Spa", 5 },
                    { 39, "Not Decorated", 3 },
                    { 38, "Thai", 3 },
                    { 37, "Modern", 3 },
                    { 36, "Minimalistic", 3 },
                    { 35, "Industrial", 3 },
                    { 34, "European", 3 },
                    { 33, "Steamroom", 5 },
                    { 32, "Playground", 5 },
                    { 31, "Lift", 5 },
                    { 30, "Indoor swimming pool", 5 },
                    { 29, "Children playroom", 5 },
                    { 28, "Spa", 5 },
                    { 27, "Outdoor swimming pool", 5 },
                    { 26, "Library", 5 },
                    { 25, "Gym/Fitness", 5 },
                    { 24, "Cafe", 5 },
                    { 23, "Sauna", 5 },
                    { 80, "To be renovated", 1 },
                    { 81, "Unfurnished", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 81);
        }
    }
}
