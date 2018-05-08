using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PathWays.Data.Model.Migrations
{
    public partial class InitialMigration : Migration
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
                name: "Organizations",
                columns: table => new
                {
                    OrganizationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
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
                    ModifiedDate = table.Column<DateTime>(nullable: true),
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
                    table.PrimaryKey("PK_Organizations", x => x.OrganizationId);
                });

            migrationBuilder.CreateTable(
                name: "SystemSettings",
                columns: table => new
                {
                    SystemSettingsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemSettings", x => x.SystemSettingsId);
                });

            migrationBuilder.CreateTable(
                name: "SystemUserRoles",
                columns: table => new
                {
                    SystemUserRoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleDescritption = table.Column<string>(maxLength: 255, nullable: false),
                    RoleName = table.Column<string>(maxLength: 50, nullable: false),
                    SessionDuration = table.Column<int>(nullable: false, defaultValue: 900)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUserRoles", x => x.SystemUserRoleId);
                });

            migrationBuilder.CreateTable(
                name: "UserExplorations",
                columns: table => new
                {
                    UserExplorationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcceptedTerms = table.Column<bool>(nullable: true),
                    AccessCode = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DomainId = table.Column<int>(nullable: false),
                    ExplorationCompletionDate = table.Column<DateTime>(nullable: false),
                    ExplorationStatus = table.Column<byte>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExplorations", x => x.UserExplorationId);
                });

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
                    table.PrimaryKey("PK_Domains", x => x.DomainId);
                    table.ForeignKey(
                        name: "FK_Domains_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SystemUsers",
                columns: table => new
                {
                    SystemUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcceptsTextMessages = table.Column<bool>(nullable: true),
                    AccountEmail = table.Column<string>(maxLength: 100, nullable: true),
                    AccountMobile = table.Column<string>(maxLength: 15, nullable: true),
                    AdminAccess = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    FullName = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Password = table.Column<string>(maxLength: 250, nullable: true),
                    SystemUserRoleId = table.Column<int>(nullable: false),
                    UserGuid = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUsers", x => x.SystemUserId);
                    table.ForeignKey(
                        name: "FK_SystemUsers_SystemUserRoles_SystemUserRoleId",
                        column: x => x.SystemUserRoleId,
                        principalTable: "SystemUserRoles",
                        principalColumn: "SystemUserRoleId",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "UserReports",
                columns: table => new
                {
                    UserReportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    UserExplorationId = table.Column<int>(nullable: false),
                    UserReportStatus = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReports", x => x.UserReportId);
                    table.ForeignKey(
                        name: "FK_UserReports_UserExplorations_UserExplorationId",
                        column: x => x.UserExplorationId,
                        principalTable: "UserExplorations",
                        principalColumn: "UserExplorationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pathways",
                columns: table => new
                {
                    PathwayId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DomainId = table.Column<int>(nullable: false),
                    FirstObjectId = table.Column<int>(nullable: true),
                    FirstObjectType = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    PathAbbreviation = table.Column<string>(maxLength: 5, nullable: false),
                    PathDescription = table.Column<string>(maxLength: 2000, nullable: false),
                    PathName = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pathways", x => x.PathwayId);
                    table.ForeignKey(
                        name: "FK_Pathways_Domains_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domains",
                        principalColumn: "DomainId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserTokenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthToken = table.Column<string>(maxLength: 250, nullable: false),
                    ExpiresOn = table.Column<DateTime>(nullable: false),
                    IssuedOn = table.Column<DateTime>(nullable: false),
                    ParticipantId = table.Column<int>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    SystemUserGuid = table.Column<Guid>(nullable: true),
                    SystemUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.UserTokenId);
                    table.ForeignKey(
                        name: "FK_UserTokens_SystemUsers_SystemUserId",
                        column: x => x.SystemUserId,
                        principalTable: "SystemUsers",
                        principalColumn: "SystemUserId",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    table.PrimaryKey("PK_Endings", x => x.EndingId);
                    table.ForeignKey(
                        name: "FK_Endings_Domains_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domains",
                        principalColumn: "DomainId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Endings_Pathways_PathwayId",
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
                    table.PrimaryKey("PK_InlineResources", x => x.InlineResourceId);
                    table.ForeignKey(
                        name: "FK_InlineResources_Domains_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domains",
                        principalColumn: "DomainId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InlineResources_Pathways_PathwayId",
                        column: x => x.PathwayId,
                        principalTable: "Pathways",
                        principalColumn: "PathwayId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DisplayId = table.Column<string>(maxLength: 20, nullable: true),
                    DomainId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    PathwayId = table.Column<int>(nullable: true),
                    QuestionTitle = table.Column<string>(maxLength: 255, nullable: true),
                    QuestionTitleText = table.Column<string>(maxLength: 1500, nullable: true),
                    QuestionType = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_Questions_Domains_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domains",
                        principalColumn: "DomainId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Questions_Pathways_PathwayId",
                        column: x => x.PathwayId,
                        principalTable: "Pathways",
                        principalColumn: "PathwayId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReportItems",
                columns: table => new
                {
                    ReportItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssociatedServiceId = table.Column<int>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    EndingDescription = table.Column<string>(maxLength: 2500, nullable: true),
                    EndingId = table.Column<int>(nullable: false),
                    EndingTitle = table.Column<string>(maxLength: 255, nullable: false),
                    EndingType = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    SystemTitle = table.Column<string>(maxLength: 500, nullable: true),
                    UserReportId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportItems", x => x.ReportItemId);
                    table.ForeignKey(
                        name: "FK_ReportItems_Endings_EndingId",
                        column: x => x.EndingId,
                        principalTable: "Endings",
                        principalColumn: "EndingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReportItems_UserReports_UserReportId",
                        column: x => x.UserReportId,
                        principalTable: "UserReports",
                        principalColumn: "UserReportId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    AnswerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnswerDisplayText = table.Column<string>(maxLength: 255, nullable: true),
                    AnswerOrder = table.Column<int>(nullable: false),
                    AnswerTitleText = table.Column<string>(maxLength: 500, nullable: true),
                    AnswerType = table.Column<int>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    NextItemId = table.Column<int>(nullable: true),
                    NextItemType = table.Column<int>(nullable: true),
                    PathwayToCreate = table.Column<int>(nullable: true),
                    QuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.AnswerId);
                    table.ForeignKey(
                        name: "FK_Answers_Pathways_PathwayToCreate",
                        column: x => x.PathwayToCreate,
                        principalTable: "Pathways",
                        principalColumn: "PathwayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_PathwayToCreate",
                table: "Answers",
                column: "PathwayToCreate");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Domains_OrganizationId",
                table: "Domains",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Endings_DomainId",
                table: "Endings",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_Endings_PathwayId",
                table: "Endings",
                column: "PathwayId");

            migrationBuilder.CreateIndex(
                name: "IX_InlineResources_DomainId",
                table: "InlineResources",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_InlineResources_PathwayId",
                table: "InlineResources",
                column: "PathwayId");

            migrationBuilder.CreateIndex(
                name: "IX_Pathways_DomainId",
                table: "Pathways",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_DomainId",
                table: "Questions",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_PathwayId",
                table: "Questions",
                column: "PathwayId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportItems_EndingId",
                table: "ReportItems",
                column: "EndingId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportItems_UserReportId",
                table: "ReportItems",
                column: "UserReportId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUsers_SystemUserRoleId",
                table: "SystemUsers",
                column: "SystemUserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExplorationTokens_UserExplorationId",
                table: "UserExplorationTokens",
                column: "UserExplorationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReports_UserExplorationId",
                table: "UserReports",
                column: "UserExplorationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_SystemUserId",
                table: "UserTokens",
                column: "SystemUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessCodeExcludeWords");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "InlineResources");

            migrationBuilder.DropTable(
                name: "ReportItems");

            migrationBuilder.DropTable(
                name: "SystemSettings");

            migrationBuilder.DropTable(
                name: "UserExplorationTokens");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Endings");

            migrationBuilder.DropTable(
                name: "UserReports");

            migrationBuilder.DropTable(
                name: "SystemUsers");

            migrationBuilder.DropTable(
                name: "Pathways");

            migrationBuilder.DropTable(
                name: "UserExplorations");

            migrationBuilder.DropTable(
                name: "SystemUserRoles");

            migrationBuilder.DropTable(
                name: "Domains");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
