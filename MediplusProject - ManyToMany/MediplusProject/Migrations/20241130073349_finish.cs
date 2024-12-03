using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediplusProject.Migrations
{
    /// <inheritdoc />
    public partial class finish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SliderItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SliderItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "SliderItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Scores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Scores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Scores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "HomeCards",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "HomeCards",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "HomeCards",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Coursels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Coursels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Coursels",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SliderItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SliderItems");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "SliderItems");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "HomeCards");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "HomeCards");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "HomeCards");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Coursels");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Coursels");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Coursels");
        }
    }
}
