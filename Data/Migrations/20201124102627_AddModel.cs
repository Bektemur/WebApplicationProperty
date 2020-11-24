using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationProperty.Data.Migrations
{
    public partial class AddModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Basics",
                columns: table => new
                {
                    BasicId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basics", x => x.BasicId);
                });

            migrationBuilder.CreateTable(
                name: "CommonAreas",
                columns: table => new
                {
                    CommonAreaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonAreas", x => x.CommonAreaId);
                });

            migrationBuilder.CreateTable(
                name: "Extras",
                columns: table => new
                {
                    ExtraId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extras", x => x.ExtraId);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    FacilitiesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.FacilitiesId);
                });

            migrationBuilder.CreateTable(
                name: "Fixtures",
                columns: table => new
                {
                    FixturesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fixtures", x => x.FixturesId);
                });

            migrationBuilder.CreateTable(
                name: "Interiors",
                columns: table => new
                {
                    InteriorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interiors", x => x.InteriorId);
                });

            migrationBuilder.CreateTable(
                name: "Others",
                columns: table => new
                {
                    OtherId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Others", x => x.OtherId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    StationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.StationId);
                });

            migrationBuilder.CreateTable(
                name: "TypeProperties",
                columns: table => new
                {
                    TypePropertyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeProperties", x => x.TypePropertyId);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    PropertyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Price_sqm = table.Column<double>(nullable: false),
                    Living_area = table.Column<double>(nullable: false),
                    Land_area = table.Column<double>(nullable: false),
                    Bathrooms = table.Column<int>(nullable: false),
                    Bedrooms = table.Column<int>(nullable: false),
                    Parking = table.Column<int>(nullable: false),
                    Public_date = table.Column<DateTime>(nullable: false),
                    Update_date = table.Column<DateTime>(nullable: false),
                    TypePropertyId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    StationId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_Properties_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Properties_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Properties_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Properties_TypeProperties_TypePropertyId",
                        column: x => x.TypePropertyId,
                        principalTable: "TypeProperties",
                        principalColumn: "TypePropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasicProperties",
                columns: table => new
                {
                    BasicId = table.Column<int>(nullable: false),
                    PropertiesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicProperties", x => new { x.BasicId, x.PropertiesId });
                    table.ForeignKey(
                        name: "FK_BasicProperties_Basics_BasicId",
                        column: x => x.BasicId,
                        principalTable: "Basics",
                        principalColumn: "BasicId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasicProperties_Properties_PropertiesId",
                        column: x => x.PropertiesId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommonAreaProperties",
                columns: table => new
                {
                    CommonAreaId = table.Column<int>(nullable: false),
                    PropertiesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonAreaProperties", x => new { x.CommonAreaId, x.PropertiesId });
                    table.ForeignKey(
                        name: "FK_CommonAreaProperties_CommonAreas_CommonAreaId",
                        column: x => x.CommonAreaId,
                        principalTable: "CommonAreas",
                        principalColumn: "CommonAreaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommonAreaProperties_Properties_PropertiesId",
                        column: x => x.PropertiesId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExtraProperies",
                columns: table => new
                {
                    ExtraId = table.Column<int>(nullable: false),
                    PropertiesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraProperies", x => new { x.ExtraId, x.PropertiesId });
                    table.ForeignKey(
                        name: "FK_ExtraProperies_Extras_ExtraId",
                        column: x => x.ExtraId,
                        principalTable: "Extras",
                        principalColumn: "ExtraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExtraProperies_Properties_PropertiesId",
                        column: x => x.PropertiesId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacilitiesProperty",
                columns: table => new
                {
                    FacilitiesId = table.Column<int>(nullable: false),
                    PropertyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilitiesProperty", x => new { x.FacilitiesId, x.PropertyId });
                    table.ForeignKey(
                        name: "FK_FacilitiesProperty_Facilities_FacilitiesId",
                        column: x => x.FacilitiesId,
                        principalTable: "Facilities",
                        principalColumn: "FacilitiesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacilitiesProperty_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FixturesProperty",
                columns: table => new
                {
                    FixturesId = table.Column<int>(nullable: false),
                    PropertiesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixturesProperty", x => new { x.FixturesId, x.PropertiesId });
                    table.ForeignKey(
                        name: "FK_FixturesProperty_Fixtures_FixturesId",
                        column: x => x.FixturesId,
                        principalTable: "Fixtures",
                        principalColumn: "FixturesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FixturesProperty_Properties_PropertiesId",
                        column: x => x.PropertiesId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InteriorProperties",
                columns: table => new
                {
                    InteriorId = table.Column<int>(nullable: false),
                    PropertiesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteriorProperties", x => new { x.InteriorId, x.PropertiesId });
                    table.ForeignKey(
                        name: "FK_InteriorProperties_Interiors_InteriorId",
                        column: x => x.InteriorId,
                        principalTable: "Interiors",
                        principalColumn: "InteriorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InteriorProperties_Properties_PropertiesId",
                        column: x => x.PropertiesId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtherProperties",
                columns: table => new
                {
                    OtherId = table.Column<int>(nullable: false),
                    PropertiesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherProperties", x => new { x.OtherId, x.PropertiesId });
                    table.ForeignKey(
                        name: "FK_OtherProperties_Others_OtherId",
                        column: x => x.OtherId,
                        principalTable: "Others",
                        principalColumn: "OtherId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OtherProperties_Properties_PropertiesId",
                        column: x => x.PropertiesId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasicProperties_PropertiesId",
                table: "BasicProperties",
                column: "PropertiesId");

            migrationBuilder.CreateIndex(
                name: "IX_CommonAreaProperties_PropertiesId",
                table: "CommonAreaProperties",
                column: "PropertiesId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraProperies_PropertiesId",
                table: "ExtraProperies",
                column: "PropertiesId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilitiesProperty_PropertyId",
                table: "FacilitiesProperty",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_FixturesProperty_PropertiesId",
                table: "FixturesProperty",
                column: "PropertiesId");

            migrationBuilder.CreateIndex(
                name: "IX_InteriorProperties_PropertiesId",
                table: "InteriorProperties",
                column: "PropertiesId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherProperties_PropertiesId",
                table: "OtherProperties",
                column: "PropertiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_ApplicationUserId",
                table: "Properties",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_ProjectId",
                table: "Properties",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_StationId",
                table: "Properties",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_TypePropertyId",
                table: "Properties",
                column: "TypePropertyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasicProperties");

            migrationBuilder.DropTable(
                name: "CommonAreaProperties");

            migrationBuilder.DropTable(
                name: "ExtraProperies");

            migrationBuilder.DropTable(
                name: "FacilitiesProperty");

            migrationBuilder.DropTable(
                name: "FixturesProperty");

            migrationBuilder.DropTable(
                name: "InteriorProperties");

            migrationBuilder.DropTable(
                name: "OtherProperties");

            migrationBuilder.DropTable(
                name: "Basics");

            migrationBuilder.DropTable(
                name: "CommonAreas");

            migrationBuilder.DropTable(
                name: "Extras");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "Fixtures");

            migrationBuilder.DropTable(
                name: "Interiors");

            migrationBuilder.DropTable(
                name: "Others");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "TypeProperties");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "AspNetUsers");
        }
    }
}
