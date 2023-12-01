using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class StudentsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "StudentInterests",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentInterests_StudentId",
                table: "StudentInterests",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_UserID",
                table: "Student",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentInterests_Student_StudentId",
                table: "StudentInterests",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentInterests_Student_StudentId",
                table: "StudentInterests");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropIndex(
                name: "IX_StudentInterests_StudentId",
                table: "StudentInterests");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "StudentInterests");
        }
    }
}
