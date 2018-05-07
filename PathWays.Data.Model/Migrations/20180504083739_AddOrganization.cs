using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PathWays.Data.Model.Migrations
{
    public partial class AddOrganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    OrganizationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DisplayLogoId = table.Column<int>(nullable: true),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    DisplaySupportChat = table.Column<bool>(nullable: true),
                    DisplaySupportEmail = table.Column<bool>(nullable: true),
                    DisplaySupportPhone = table.Column<bool>(nullable: true),
                    DisplayUserSupport = table.Column<bool>(nullable: true),
                    FlatMonthlyFee = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    FullName = table.Column<string>(maxLength: 200, nullable: false),
                    LicenseType = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    OrganizationGuid = table.Column<Guid>(nullable: false),
                    OrganizationStatus = table.Column<int>(nullable: true),
                    PerComplationFee = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    PerServiceAccessFee = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    PerVisitFee = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    SupportChatDescription = table.Column<string>(maxLength: 1000, nullable: true),
                    SupportChatUrl = table.Column<string>(maxLength: 1000, nullable: true),
                    SupportEmail = table.Column<string>(maxLength: 100, nullable: true),
                    SupportEmailDescription = table.Column<string>(maxLength: 1000, nullable: true),
                    SupportPhone1 = table.Column<string>(maxLength: 15, nullable: true),
                    SupportPhone1Description = table.Column<string>(maxLength: 1000, nullable: true),
                    SupportPhone2 = table.Column<string>(maxLength: 15, nullable: true),
                    SupportPhone2Description = table.Column<string>(maxLength: 1000, nullable: true),
                    TimeZoneOffset = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.OrganizationId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Organization");
        }
    }
}
