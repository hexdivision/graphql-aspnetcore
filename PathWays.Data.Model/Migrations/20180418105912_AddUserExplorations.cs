using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PathWays.Data.Model.Migrations
{
    public partial class AddUserExplorations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessCodeExcludeWords",
                columns: table => new
                {
                    AccessCodeExcludeWordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExcludeWord = table.Column<string>(maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessCodeExcludeWords", x => x.AccessCodeExcludeWordId);
                });

            migrationBuilder.CreateTable(
                name: "UserExplorations",
                columns: table => new
                {
                    UserExplorationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcceptedTerms = table.Column<bool>(nullable: true),
                    AccessCode = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DomainId = table.Column<int>(nullable: false),
                    ExplorationCompletionDate = table.Column<DateTime>(nullable: false),
                    ExplorationStatus = table.Column<byte>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    OrganizationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExplorations", x => x.UserExplorationId);
                });

            migrationBuilder.CreateTable(
                name: "UserExplorationTokens",
                columns: table => new
                {
                    UserExplorationTokenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessCode = table.Column<string>(maxLength: 15, nullable: true),
                    AuthToken = table.Column<string>(maxLength: 250, nullable: false),
                    ExpiresOn = table.Column<DateTime>(nullable: false),
                    ExplorationId = table.Column<int>(nullable: true),
                    IssuedOn = table.Column<DateTime>(nullable: false),
                    RoleId = table.Column<byte>(nullable: false),
                    SystemUserId = table.Column<int>(nullable: true),
                    UserExplorationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExplorationTokens", x => x.UserExplorationTokenId);
                    table.ForeignKey(
                        name: "FK_UserExplorationTokens_UserExplorations_UserExplorationId",
                        column: x => x.UserExplorationId,
                        principalTable: "UserExplorations",
                        principalColumn: "UserExplorationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserExplorationTokens_UserExplorationId",
                table: "UserExplorationTokens",
                column: "UserExplorationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessCodeExcludeWords");

            migrationBuilder.DropTable(
                name: "UserExplorationTokens");

            migrationBuilder.DropTable(
                name: "UserExplorations");
        }
    }
}
