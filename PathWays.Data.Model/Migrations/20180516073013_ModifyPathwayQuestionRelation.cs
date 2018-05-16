using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PathWays.Data.Model.Migrations
{
    public partial class ModifyPathwayQuestionRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSteps_Questions_QuestionId",
                table: "UserSteps");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserSteps_Questions_QuestionId",
                table: "UserSteps",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSteps_Questions_QuestionId",
                table: "UserSteps");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserSteps_Questions_QuestionId",
                table: "UserSteps",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "PathwayId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
