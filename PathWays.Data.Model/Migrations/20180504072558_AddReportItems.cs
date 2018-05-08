using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PathWays.Data.Model.Migrations
{
    public partial class AddReportItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReportItems",
                columns: table => new
                {
                    ReportItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssociatedServiceId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    EndingDescription = table.Column<string>(maxLength: 2500, nullable: true),
                    EndingId = table.Column<int>(nullable: false),
                    EndingTitle = table.Column<string>(maxLength: 255, nullable: false),
                    EndingType = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    SystemTitle = table.Column<string>(maxLength: 500, nullable: true),
                    UserReportId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportItems", x => x.ReportItemId);
                    table.ForeignKey(
                        name: "FK_ReportItems_UserReports_UserReportId",
                        column: x => x.UserReportId,
                        principalTable: "UserReports",
                        principalColumn: "UserReportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportItems_UserReportId",
                table: "ReportItems",
                column: "UserReportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportItems");
        }
    }
}
