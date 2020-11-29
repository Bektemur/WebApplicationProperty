using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationProperty.Data.Migrations
{
    public partial class AddFileSystemModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FilesOnFileSystem_PropertyId",
                table: "FilesOnFileSystem",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilesOnFileSystem_Properties_PropertyId",
                table: "FilesOnFileSystem",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "PropertyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilesOnFileSystem_Properties_PropertyId",
                table: "FilesOnFileSystem");

            migrationBuilder.DropIndex(
                name: "IX_FilesOnFileSystem_PropertyId",
                table: "FilesOnFileSystem");
        }
    }
}
