using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PathWays.Data.Model.Migrations
{
    public partial class AddTimeStamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "UserExplorations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "UserExplorations",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "SystemUsers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "SystemUsers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "AccessCodeExcludeWords",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AccessCodeExcludeWords",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "AccessCodeExcludeWords",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "AccessCodeExcludeWords",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "UserExplorations");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "UserExplorations");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AccessCodeExcludeWords");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AccessCodeExcludeWords");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "AccessCodeExcludeWords");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "AccessCodeExcludeWords");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "SystemUsers",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "SystemUsers",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
