using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PathWays.Data.Model.Migrations
{
    public partial class AddEndingInlineResource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endings",
                columns: table => new
                {
                    EndingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DomainId = table.Column<int>(nullable: false),
                    EndingDescription = table.Column<string>(nullable: true),
                    EndingTitle = table.Column<string>(nullable: false),
                    EndingType = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    PathwayId = table.Column<int>(nullable: true),
                    ReturnInstructions = table.Column<string>(nullable: true),
                    ReturnNextItemId = table.Column<int>(nullable: true),
                    ReturnNextItemType = table.Column<int>(nullable: false),
                    ServiceId = table.Column<int>(nullable: true),
                    SystemTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ending", x => x.EndingId);
                    table.ForeignKey(
                        name: "FK_Ending_Domain_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domains",
                        principalColumn: "DomainId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ending_Pathway_PathwayId",
                        column: x => x.PathwayId,
                        principalTable: "Pathways",
                        principalColumn: "PathwayId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InlineResources",
                columns: table => new
                {
                    InlineResourceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DisplayId = table.Column<string>(maxLength: 20, nullable: true),
                    DomainId = table.Column<int>(nullable: false),
                    ExternalUrl = table.Column<string>(maxLength: 1000, nullable: true),
                    IsDeleted = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    NextItemId = table.Column<int>(nullable: true),
                    NextItemType = table.Column<int>(nullable: true),
                    PathwayId = table.Column<int>(nullable: false),
                    ResourceDescription = table.Column<string>(maxLength: 2000, nullable: true),
                    ResourceInstructions = table.Column<string>(maxLength: 2000, nullable: true),
                    ResourceTitle = table.Column<string>(maxLength: 255, nullable: true),
                    ResourceType = table.Column<int>(nullable: false),
                    SharePublicly = table.Column<bool>(nullable: true),
                    TemplateDoc = table.Column<int>(nullable: true),
                    TemplateHtml = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InlineResource", x => x.InlineResourceId);
                    table.ForeignKey(
                        name: "FK_InlineResource_Domain_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domains",
                        principalColumn: "DomainId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InlineResource_Pathway_PathwayId",
                        column: x => x.PathwayId,
                        principalTable: "Pathways",
                        principalColumn: "PathwayId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ending_DomainId",
                table: "Endings",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_Ending_PathwayId",
                table: "Endings",
                column: "PathwayId");

            migrationBuilder.CreateIndex(
                name: "IX_InlineResource_DomainId",
                table: "InlineResources",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_InlineResource_PathwayId",
                table: "InlineResources",
                column: "PathwayId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endings");

            migrationBuilder.DropTable(
                name: "InlineResources");
        }
    }
}
