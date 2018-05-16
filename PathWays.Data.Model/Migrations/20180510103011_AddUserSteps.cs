using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PathWays.Data.Model.Migrations
{
    public partial class AddUserSteps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Questions_PathwayId",
                table: "Questions");

            migrationBuilder.AlterColumn<int>(
                name: "PathwayId",
                table: "Questions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Questions_PathwayId",
                table: "Questions",
                column: "PathwayId");

            migrationBuilder.CreateTable(
                name: "UserSteps",
                columns: table => new
                {
                    UserStepId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnswerDisplayText = table.Column<string>(nullable: true),
                    AnswerId = table.Column<int>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    InlineResourceId = table.Column<int>(nullable: true),
                    InlineResourceType = table.Column<int>(nullable: true),
                    InternalResourceAction = table.Column<int>(nullable: true),
                    InternalResourceRating = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    QuestionId = table.Column<int>(nullable: true),
                    ResourceDescriptionText = table.Column<string>(nullable: true),
                    ResourceResultData = table.Column<string>(nullable: true),
                    ResourceResultText = table.Column<string>(maxLength: 2000, nullable: true),
                    ResourceTitle = table.Column<string>(maxLength: 200, nullable: true),
                    StepCount = table.Column<int>(nullable: true),
                    StepType = table.Column<int>(nullable: false),
                    UserExplorationId = table.Column<int>(nullable: false),
                    UserPathwayId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSteps", x => x.UserStepId);
                    table.ForeignKey(
                        name: "FK_UserSteps_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "AnswerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSteps_InlineResources_InlineResourceId",
                        column: x => x.InlineResourceId,
                        principalTable: "InlineResources",
                        principalColumn: "InlineResourceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSteps_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "PathwayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSteps_UserExplorations_UserExplorationId",
                        column: x => x.UserExplorationId,
                        principalTable: "UserExplorations",
                        principalColumn: "UserExplorationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSteps_UserPathways_UserPathwayId",
                        column: x => x.UserPathwayId,
                        principalTable: "UserPathways",
                        principalColumn: "UserPathwayId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSteps_AnswerId",
                table: "UserSteps",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSteps_InlineResourceId",
                table: "UserSteps",
                column: "InlineResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSteps_QuestionId",
                table: "UserSteps",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSteps_UserExplorationId",
                table: "UserSteps",
                column: "UserExplorationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSteps_UserPathwayId",
                table: "UserSteps",
                column: "UserPathwayId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSteps");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Questions_PathwayId",
                table: "Questions");

            migrationBuilder.AlterColumn<int>(
                name: "PathwayId",
                table: "Questions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Questions_PathwayId",
                table: "Questions",
                column: "PathwayId");
        }
    }
}
