using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PromactManagement.DomainModel.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "organizationModules",
                columns: table => new
                {
                    OrganizationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationName = table.Column<string>(maxLength: 100, nullable: false),
                    OrganizationOwnerEmailId = table.Column<string>(maxLength: 200, nullable: false),
                    PartnerLevel = table.Column<string>(nullable: false),
                    ActiveCompany = table.Column<int>(nullable: false),
                    OrganizationStatus = table.Column<bool>(nullable: false),
                    OrganizationType = table.Column<string>(nullable: true),
                    Partnersince = table.Column<int>(nullable: false),
                    UseOverrides = table.Column<bool>(nullable: false),
                    AUAOverride = table.Column<string>(nullable: true),
                    VCOverride = table.Column<string>(nullable: true),
                    CostsLastQuarter = table.Column<string>(nullable: true),
                    ActiveSince = table.Column<DateTime>(type: "date", nullable: false),
                    Notes = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizationModules", x => x.OrganizationId);
                });

            migrationBuilder.CreateTable(
                name: "companyModules",
                columns: table => new
                {
                    ComapnyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(nullable: true),
                    CompanyOwner = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: false),
                    PartnerLevel = table.Column<string>(nullable: true),
                    CompanyStatus = table.Column<bool>(nullable: false),
                    CompanyCreateDate = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    website = table.Column<string>(nullable: true),
                    URLLinke = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companyModules", x => x.ComapnyId);
                    table.ForeignKey(
                        name: "FK_companyModules_organizationModules_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "organizationModules",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_companyModules_OrganizationId",
                table: "companyModules",
                column: "OrganizationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "companyModules");

            migrationBuilder.DropTable(
                name: "organizationModules");
        }
    }
}
