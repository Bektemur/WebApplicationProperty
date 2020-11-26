using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationProperty.Data.Migrations
{
    public partial class FixesFileLoad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilesOnDatabase_Properties_PropertiesId",
                table: "FilesOnDatabase");

            migrationBuilder.DropIndex(
                name: "IX_FilesOnDatabase_PropertiesId",
                table: "FilesOnDatabase");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FilesOnDatabase_PropertiesId",
                table: "FilesOnDatabase",
                column: "PropertiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilesOnDatabase_Properties_PropertiesId",
                table: "FilesOnDatabase",
                column: "PropertiesId",
                principalTable: "Properties",
                principalColumn: "PropertyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
