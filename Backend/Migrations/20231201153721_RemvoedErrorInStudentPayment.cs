using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class RemvoedErrorInStudentPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentPayment_StudentCourses_StudentCoursesId",
                table: "StudentPayment");

            migrationBuilder.DropIndex(
                name: "IX_StudentPayment_StudentCoursesId",
                table: "StudentPayment");

            migrationBuilder.DropColumn(
                name: "StudentCoursesId",
                table: "StudentPayment");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_StudentPaymentId",
                table: "StudentCourses",
                column: "StudentPaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_StudentPayment_StudentPaymentId",
                table: "StudentCourses",
                column: "StudentPaymentId",
                principalTable: "StudentPayment",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_StudentPayment_StudentPaymentId",
                table: "StudentCourses");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourses_StudentPaymentId",
                table: "StudentCourses");

            migrationBuilder.AddColumn<int>(
                name: "StudentCoursesId",
                table: "StudentPayment",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentPayment_StudentCoursesId",
                table: "StudentPayment",
                column: "StudentCoursesId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPayment_StudentCourses_StudentCoursesId",
                table: "StudentPayment",
                column: "StudentCoursesId",
                principalTable: "StudentCourses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
