using Microsoft.EntityFrameworkCore.Migrations;

namespace PromactManagement.DomainModel.Migrations
{
    public partial class new1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_companyModules_organizationModules_OrganizationId",
                table: "companyModules");

            migrationBuilder.DropIndex(
                name: "IX_companyModules_OrganizationId",
                table: "companyModules");

            migrationBuilder.AlterColumn<string>(
                name: "VCOverride",
                table: "organizationModules",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PartnerLevel",
                table: "organizationModules",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationType",
                table: "organizationModules",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CostsLastQuarter",
                table: "organizationModules",
                maxLength: 9,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AUAOverride",
                table: "organizationModules",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationModuleOrganizationId",
                table: "companyModules",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_companyModules_OrganizationModuleOrganizationId",
                table: "companyModules",
                column: "OrganizationModuleOrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_companyModules_organizationModules_OrganizationModuleOrganizationId",
                table: "companyModules",
                column: "OrganizationModuleOrganizationId",
                principalTable: "organizationModules",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_companyModules_organizationModules_OrganizationModuleOrganizationId",
                table: "companyModules");

            migrationBuilder.DropIndex(
                name: "IX_companyModules_OrganizationModuleOrganizationId",
                table: "companyModules");

            migrationBuilder.DropColumn(
                name: "OrganizationModuleOrganizationId",
                table: "companyModules");

            migrationBuilder.AlterColumn<string>(
                name: "VCOverride",
                table: "organizationModules",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PartnerLevel",
                table: "organizationModules",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "OrganizationType",
                table: "organizationModules",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "CostsLastQuarter",
                table: "organizationModules",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 9,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AUAOverride",
                table: "organizationModules",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 6,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_companyModules_OrganizationId",
                table: "companyModules",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_companyModules_organizationModules_OrganizationId",
                table: "companyModules",
                column: "OrganizationId",
                principalTable: "organizationModules",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
