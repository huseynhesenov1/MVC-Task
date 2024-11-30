using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediplusProject.Migrations
{
    /// <inheritdoc />
    public partial class deletebaseentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateAtDate",
                table: "SliderItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SliderItems");

            migrationBuilder.DropColumn(
                name: "UpdateAtDate",
                table: "SliderItems");

            migrationBuilder.DropColumn(
                name: "CreateAtDate",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "UpdateAtDate",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "CreateAtDate",
                table: "HomeCards");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "HomeCards");

            migrationBuilder.DropColumn(
                name: "UpdateAtDate",
                table: "HomeCards");

            migrationBuilder.DropColumn(
                name: "CreateAtDate",
                table: "Coursels");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Coursels");

            migrationBuilder.DropColumn(
                name: "UpdateAtDate",
                table: "Coursels");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAtDate",
                table: "SliderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SliderItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAtDate",
                table: "SliderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAtDate",
                table: "Scores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Scores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAtDate",
                table: "Scores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAtDate",
                table: "HomeCards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "HomeCards",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAtDate",
                table: "HomeCards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAtDate",
                table: "Coursels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Coursels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAtDate",
                table: "Coursels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
