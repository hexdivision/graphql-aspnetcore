using Microsoft.EntityFrameworkCore.Migrations;

namespace PathWays.Data.Model.Migrations
{
    public partial class AddFieldsToQuestionsAndAnswers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeadEnds",
                table: "Questions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EnableChat",
                table: "Questions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxNodesAhead",
                table: "Answers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeadEnds",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "EnableChat",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "MaxNodesAhead",
                table: "Answers");
        }
    }
}
