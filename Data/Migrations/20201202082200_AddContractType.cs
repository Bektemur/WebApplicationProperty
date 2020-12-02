using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationProperty.Data.Migrations
{
    public partial class AddContractType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContractTypeId",
                table: "Properties",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Price_rent",
                table: "Properties",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "ContractType",
                columns: table => new
                {
                    ContractTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractType", x => x.ContractTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_ContractTypeId",
                table: "Properties",
                column: "ContractTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_ContractType_ContractTypeId",
                table: "Properties",
                column: "ContractTypeId",
                principalTable: "ContractType",
                principalColumn: "ContractTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_ContractType_ContractTypeId",
                table: "Properties");

            migrationBuilder.DropTable(
                name: "ContractType");

            migrationBuilder.DropIndex(
                name: "IX_Properties_ContractTypeId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "ContractTypeId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Price_rent",
                table: "Properties");
        }
    }
}
