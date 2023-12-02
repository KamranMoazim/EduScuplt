using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedNulls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCourseVideoLikes");

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "StudentPayment",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "StudentPayment");

            migrationBuilder.CreateTable(
                name: "StudentCourseVideoLikes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseVideoId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsLiked = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourseVideoLikes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StudentCourseVideoLikes_CourseVideos_CourseVideoId",
                        column: x => x.CourseVideoId,
                        principalTable: "CourseVideos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourseVideoLikes_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseVideoLikes_CourseVideoId",
                table: "StudentCourseVideoLikes",
                column: "CourseVideoId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseVideoLikes_StudentId",
                table: "StudentCourseVideoLikes",
                column: "StudentId");
        }
    }
}
