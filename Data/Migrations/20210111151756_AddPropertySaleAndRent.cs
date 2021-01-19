using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationProperty.Data.Migrations
{
    public partial class AddPropertySaleAndRent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_ContractTypes_ContractTypeId",
                table: "Properties");

            migrationBuilder.AlterColumn<int>(
                name: "ContractTypeId",
                table: "Properties",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "ForRent",
                table: "Properties",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ForSale",
                table: "Properties",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "PriceForRent",
                table: "Properties",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PriceForSale",
                table: "Properties",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_ContractTypes_ContractTypeId",
                table: "Properties",
                column: "ContractTypeId",
                principalTable: "ContractTypes",
                principalColumn: "ContractTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_ContractTypes_ContractTypeId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "ForRent",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "ForSale",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PriceForRent",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PriceForSale",
                table: "Properties");

            migrationBuilder.AlterColumn<int>(
                name: "ContractTypeId",
                table: "Properties",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_ContractTypes_ContractTypeId",
                table: "Properties",
                column: "ContractTypeId",
                principalTable: "ContractTypes",
                principalColumn: "ContractTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
