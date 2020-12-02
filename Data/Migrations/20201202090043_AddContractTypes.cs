using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationProperty.Data.Migrations
{
    public partial class AddContractTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_ContractType_ContractTypeId",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractType",
                table: "ContractType");

            migrationBuilder.RenameTable(
                name: "ContractType",
                newName: "ContractTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractTypes",
                table: "ContractTypes",
                column: "ContractTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_ContractTypes_ContractTypeId",
                table: "Properties",
                column: "ContractTypeId",
                principalTable: "ContractTypes",
                principalColumn: "ContractTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_ContractTypes_ContractTypeId",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractTypes",
                table: "ContractTypes");

            migrationBuilder.RenameTable(
                name: "ContractTypes",
                newName: "ContractType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractType",
                table: "ContractType",
                column: "ContractTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_ContractType_ContractTypeId",
                table: "Properties",
                column: "ContractTypeId",
                principalTable: "ContractType",
                principalColumn: "ContractTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
