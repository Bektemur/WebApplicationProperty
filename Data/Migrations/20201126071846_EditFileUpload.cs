using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationProperty.Data.Migrations
{
    public partial class EditFileUpload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilesOnDatabase_Properties_PropertiesPropertyId",
                table: "FilesOnDatabase");

            migrationBuilder.DropIndex(
                name: "IX_FilesOnDatabase_PropertiesPropertyId",
                table: "FilesOnDatabase");

            migrationBuilder.DropColumn(
                name: "PropertiesPropertyId",
                table: "FilesOnDatabase");

            migrationBuilder.AddColumn<int>(
                name: "PropertiesId",
                table: "FilesOnDatabase",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilesOnDatabase_Properties_PropertiesId",
                table: "FilesOnDatabase");

            migrationBuilder.DropIndex(
                name: "IX_FilesOnDatabase_PropertiesId",
                table: "FilesOnDatabase");

            migrationBuilder.DropColumn(
                name: "PropertiesId",
                table: "FilesOnDatabase");

            migrationBuilder.AddColumn<int>(
                name: "PropertiesPropertyId",
                table: "FilesOnDatabase",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FilesOnDatabase_PropertiesPropertyId",
                table: "FilesOnDatabase",
                column: "PropertiesPropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilesOnDatabase_Properties_PropertiesPropertyId",
                table: "FilesOnDatabase",
                column: "PropertiesPropertyId",
                principalTable: "Properties",
                principalColumn: "PropertyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
