using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PathWays.Data.Model.Migrations
{
    public partial class AddPathwayQuestionAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    table.PrimaryKey("PK_Pathway", x => x.PathwayId);
                    table.ForeignKey(
                        name: "FK_Pathway_Domain_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domains",
                        principalColumn: "DomainId",
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
                    table.PrimaryKey("PK_Question", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_Question_Domain_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domains",
                        principalColumn: "DomainId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Question_Pathway_PathwayId",
                        column: x => x.PathwayId,
                        principalTable: "Pathways",
                        principalColumn: "PathwayId",
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
                    table.PrimaryKey("PK_Answer", x => x.AnswerId);
                    table.ForeignKey(
                        name: "FK_Answer_Pathway_PathwayToCreate",
                        column: x => x.PathwayToCreate,
                        principalTable: "Pathways",
                        principalColumn: "PathwayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answer_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_PathwayToCreate",
                table: "Answers",
                column: "PathwayToCreate");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Pathway_DomainId",
                table: "Pathways",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_DomainId",
                table: "Questions",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_PathwayId",
                table: "Questions",
                column: "PathwayId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Pathways");
        }
    }
}
