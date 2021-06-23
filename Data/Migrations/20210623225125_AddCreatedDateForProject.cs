using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationProperty.Data.Migrations
{
    public partial class AddCreatedDateForProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Projects",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Projects");
        }
    }
}
