using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PathWays.Data.Model.Migrations
{
    public partial class RemoveFieldsFromUserToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPathways_Pathways_PathwayId",
                table: "UserPathways");

            migrationBuilder.DropColumn(
                name: "ParticipantId",
                table: "UserTokens");

            migrationBuilder.DropColumn(
                name: "SystemUserGuid",
                table: "UserTokens");

            migrationBuilder.AlterColumn<int>(
                name: "PathwayId",
                table: "UserPathways",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPathways_Pathways_PathwayId",
                table: "UserPathways",
                column: "PathwayId",
                principalTable: "Pathways",
                principalColumn: "PathwayId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPathways_Pathways_PathwayId",
                table: "UserPathways");

            migrationBuilder.AddColumn<int>(
                name: "ParticipantId",
                table: "UserTokens",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SystemUserGuid",
                table: "UserTokens",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PathwayId",
                table: "UserPathways",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_UserPathways_Pathways_PathwayId",
                table: "UserPathways",
                column: "PathwayId",
                principalTable: "Pathways",
                principalColumn: "PathwayId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
