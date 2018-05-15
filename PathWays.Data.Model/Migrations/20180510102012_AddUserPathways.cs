using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PathWays.Data.Model.Migrations
{
    public partial class AddUserPathways : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserPathways",
                columns: table => new
                {
                    UserPathwayId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    PathwayCompletionDate = table.Column<DateTime>(nullable: true),
                    PathwayId = table.Column<int>(nullable: true),
                    PathwayStatus = table.Column<int>(nullable: true),
                    PathwayTitle = table.Column<string>(maxLength: 100, nullable: true),
                    PathwayType = table.Column<int>(nullable: false),
                    UserExplorationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPathways", x => x.UserPathwayId);
                    table.ForeignKey(
                        name: "FK_UserPathways_Pathways_PathwayId",
                        column: x => x.PathwayId,
                        principalTable: "Pathways",
                        principalColumn: "PathwayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserPathways_UserExplorations_UserExplorationId",
                        column: x => x.UserExplorationId,
                        principalTable: "UserExplorations",
                        principalColumn: "UserExplorationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPathways_PathwayId",
                table: "UserPathways",
                column: "PathwayId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPathways_UserExplorationId",
                table: "UserPathways",
                column: "UserExplorationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPathways");
        }
    }
}
