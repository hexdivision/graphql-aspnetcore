using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PathWays.Data.Model.Migrations
{
    public partial class AddDomain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Domains",
                columns: table => new
                {
                    DomainId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DomainAbbreviation = table.Column<string>(maxLength: 7, nullable: true),
                    DomainDescription = table.Column<string>(maxLength: 500, nullable: true),
                    DomainEmbedCode = table.Column<string>(maxLength: 20, nullable: true),
                    DomainTitle = table.Column<string>(maxLength: 150, nullable: true),
                    EnforceTerms = table.Column<bool>(nullable: true),
                    FirstObjectId = table.Column<int>(nullable: true),
                    FirstObjectType = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: true),
                    TermsOfUseHtml = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domain", x => x.DomainId);
                    table.ForeignKey(
                        name: "FK_Domain_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Domain_OrganizationId",
                table: "Domains",
                column: "OrganizationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Domains");
        }
    }
}
