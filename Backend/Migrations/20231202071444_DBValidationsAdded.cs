using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class DBValidationsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Admin_ApprovedById",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseVideos_CourseFolders_CourseFoldersID",
                table: "CourseVideos");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Admin_ApprovedById",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentPayment_CourseDiscounts_CourseDiscountId",
                table: "StudentPayment");

            migrationBuilder.RenameColumn(
                name: "CourseFoldersID",
                table: "CourseVideos",
                newName: "CourseFoldersId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseVideos_CourseFoldersID",
                table: "CourseVideos",
                newName: "IX_CourseVideos_CourseFoldersId");

            migrationBuilder.AlterColumn<int>(
                name: "CourseDiscountId",
                table: "StudentPayment",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Review",
                table: "StudentCourses",
                type: "TEXT",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "StudentCourses",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "StudentCourses",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReviewed",
                table: "StudentCourses",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "ApprovedById",
                table: "Instructors",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "AccountDetails",
                table: "Instructors",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "ThumbnailURL",
                table: "Courses",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "ApprovedById",
                table: "Courses",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Admin_ApprovedById",
                table: "Courses",
                column: "ApprovedById",
                principalTable: "Admin",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseVideos_CourseFolders_CourseFoldersId",
                table: "CourseVideos",
                column: "CourseFoldersId",
                principalTable: "CourseFolders",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Admin_ApprovedById",
                table: "Instructors",
                column: "ApprovedById",
                principalTable: "Admin",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPayment_CourseDiscounts_CourseDiscountId",
                table: "StudentPayment",
                column: "CourseDiscountId",
                principalTable: "CourseDiscounts",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Admin_ApprovedById",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseVideos_CourseFolders_CourseFoldersId",
                table: "CourseVideos");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Admin_ApprovedById",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentPayment_CourseDiscounts_CourseDiscountId",
                table: "StudentPayment");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "IsReviewed",
                table: "StudentCourses");

            migrationBuilder.RenameColumn(
                name: "CourseFoldersId",
                table: "CourseVideos",
                newName: "CourseFoldersID");

            migrationBuilder.RenameIndex(
                name: "IX_CourseVideos_CourseFoldersId",
                table: "CourseVideos",
                newName: "IX_CourseVideos_CourseFoldersID");

            migrationBuilder.AlterColumn<int>(
                name: "CourseDiscountId",
                table: "StudentPayment",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Review",
                table: "StudentCourses",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "StudentCourses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApprovedById",
                table: "Instructors",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccountDetails",
                table: "Instructors",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ThumbnailURL",
                table: "Courses",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApprovedById",
                table: "Courses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Admin_ApprovedById",
                table: "Courses",
                column: "ApprovedById",
                principalTable: "Admin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseVideos_CourseFolders_CourseFoldersID",
                table: "CourseVideos",
                column: "CourseFoldersID",
                principalTable: "CourseFolders",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Admin_ApprovedById",
                table: "Instructors",
                column: "ApprovedById",
                principalTable: "Admin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPayment_CourseDiscounts_CourseDiscountId",
                table: "StudentPayment",
                column: "CourseDiscountId",
                principalTable: "CourseDiscounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
