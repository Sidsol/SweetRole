using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SweetRole.Migrations
{
    public partial class AddedCharacterDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BackStory",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EyeColor",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HairColor",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Height",
                table: "Characters",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Miscellaneous",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Race",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SexualOrientation",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Species",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Characters",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackStory",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "EyeColor",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "HairColor",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Miscellaneous",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Race",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SexualOrientation",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Species",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Characters");
        }
    }
}
