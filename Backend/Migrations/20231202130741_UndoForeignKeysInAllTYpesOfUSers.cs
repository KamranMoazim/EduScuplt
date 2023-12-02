using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class UndoForeignKeysInAllTYpesOfUSers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Student",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "InstructorId",
                table: "Instructors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "Admin",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Student",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Instructors",
                newName: "InstructorId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Admin",
                newName: "AdminId");
        }
    }
}
