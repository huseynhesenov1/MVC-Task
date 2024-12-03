using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediplusProject.Migrations
{
    /// <inheritdoc />
    public partial class manytomanytable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hosbitals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hosbitals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HosbitalDoctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HosbitalId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HosbitalDoctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HosbitalDoctors_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HosbitalDoctors_Hosbitals_HosbitalId",
                        column: x => x.HosbitalId,
                        principalTable: "Hosbitals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HosbitalDoctors_DoctorId",
                table: "HosbitalDoctors",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_HosbitalDoctors_HosbitalId",
                table: "HosbitalDoctors",
                column: "HosbitalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HosbitalDoctors");

            migrationBuilder.DropTable(
                name: "Hosbitals");
        }
    }
}
