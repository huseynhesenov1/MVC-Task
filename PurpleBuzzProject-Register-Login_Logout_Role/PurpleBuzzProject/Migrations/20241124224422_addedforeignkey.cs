using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PurpleBuzzProject.Migrations
{
    /// <inheritdoc />
    public partial class addedforeignkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OurServiceId",
                table: "OurWorks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OurServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurServices", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OurWorks_OurServiceId",
                table: "OurWorks",
                column: "OurServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_OurWorks_OurServices_OurServiceId",
                table: "OurWorks",
                column: "OurServiceId",
                principalTable: "OurServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OurWorks_OurServices_OurServiceId",
                table: "OurWorks");

            migrationBuilder.DropTable(
                name: "OurServices");

            migrationBuilder.DropIndex(
                name: "IX_OurWorks_OurServiceId",
                table: "OurWorks");

            migrationBuilder.DropColumn(
                name: "OurServiceId",
                table: "OurWorks");
        }
    }
}
