using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class StudentsCourseVideoLikes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseVideos_Courses_CourseID",
                table: "CourseVideos");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Users_UserID",
                table: "Student");

            migrationBuilder.DropTable(
                name: "CourseVideoLikes");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Student",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_UserID",
                table: "Student",
                newName: "IX_Student_UserId");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "CourseVideos",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseVideos_CourseID",
                table: "CourseVideos",
                newName: "IX_CourseVideos_CourseId");

            migrationBuilder.CreateTable(
                name: "StudentCourseVideoLikes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsLiked = table.Column<bool>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseVideoId = table.Column<int>(type: "INTEGER", nullable: false)
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

            migrationBuilder.AddForeignKey(
                name: "FK_CourseVideos_Courses_CourseId",
                table: "CourseVideos",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Users_UserId",
                table: "Student",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseVideos_Courses_CourseId",
                table: "CourseVideos");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Users_UserId",
                table: "Student");

            migrationBuilder.DropTable(
                name: "StudentCourseVideoLikes");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Student",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Student_UserId",
                table: "Student",
                newName: "IX_Student_UserID");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "CourseVideos",
                newName: "CourseID");

            migrationBuilder.RenameIndex(
                name: "IX_CourseVideos_CourseId",
                table: "CourseVideos",
                newName: "IX_CourseVideos_CourseID");

            migrationBuilder.CreateTable(
                name: "CourseVideoLikes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseVideoID = table.Column<int>(type: "INTEGER", nullable: false),
                    UserID = table.Column<int>(type: "INTEGER", nullable: false),
                    Disliked = table.Column<bool>(type: "INTEGER", nullable: false),
                    Liked = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseVideoLikes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CourseVideoLikes_CourseVideos_CourseVideoID",
                        column: x => x.CourseVideoID,
                        principalTable: "CourseVideos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseVideoLikes_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseVideoLikes_CourseVideoID",
                table: "CourseVideoLikes",
                column: "CourseVideoID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseVideoLikes_UserID",
                table: "CourseVideoLikes",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseVideos_Courses_CourseID",
                table: "CourseVideos",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Users_UserID",
                table: "Student",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
