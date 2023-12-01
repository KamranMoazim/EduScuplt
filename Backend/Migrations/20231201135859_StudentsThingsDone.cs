using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class StudentsThingsDone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseDiscounts_Courses_CourseID",
                table: "CourseDiscounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Instructors_InstructorID",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Users_UserID",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_CourseVideos_CourseVideoID",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_UserID",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_VideoComments_VideoCommentID",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Courses_CourseID",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Users_StudentID",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoComments_CourseVideos_ID",
                table: "VideoComments");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoComments_Users_ID",
                table: "VideoComments");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoComments_Users_ReplyToID",
                table: "VideoComments");

            migrationBuilder.DropTable(
                name: "CourseProgress");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_VideoCommentID",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "VideoCommentID",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "About",
                table: "Instructors");

            migrationBuilder.RenameColumn(
                name: "ReplyToID",
                table: "VideoComments",
                newName: "ReplyToId");

            migrationBuilder.RenameIndex(
                name: "IX_VideoComments_ReplyToID",
                table: "VideoComments",
                newName: "IX_VideoComments_ReplyToId");

            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "StudentCourses",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "StudentCourses",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "DateJoined",
                table: "StudentCourses",
                newName: "LastProgressDate");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourses_StudentID",
                table: "StudentCourses",
                newName: "IX_StudentCourses_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourses_CourseID",
                table: "StudentCourses",
                newName: "IX_StudentCourses_CourseId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Notifications",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_UserID",
                table: "Notifications",
                newName: "IX_Notifications_UserId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Instructors",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "EarnedAmount",
                table: "Instructors",
                newName: "WithdrawnAmount");

            migrationBuilder.RenameIndex(
                name: "IX_Instructors_UserID",
                table: "Instructors",
                newName: "IX_Instructors_UserId");

            migrationBuilder.RenameColumn(
                name: "InstructorID",
                table: "Courses",
                newName: "InstructorId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_InstructorID",
                table: "Courses",
                newName: "IX_Courses_InstructorId");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "CourseDiscounts",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseDiscounts_CourseID",
                table: "CourseDiscounts",
                newName: "IX_CourseDiscounts_CourseId");

            migrationBuilder.AlterColumn<int>(
                name: "ReplyToId",
                table: "VideoComments",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "VideoComments",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "CommentById",
                table: "VideoComments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseVideoId",
                table: "VideoComments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "VideoComments",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CourseCompleteDate",
                table: "StudentCourses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "CourseCompleteProgressPercentage",
                table: "StudentCourses",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CourseStartDate",
                table: "StudentCourses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "StudentPaymentId",
                table: "StudentCourses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CourseVideoID",
                table: "Notifications",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Notifications",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NotificationType",
                table: "Notifications",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RelatedEntityId",
                table: "Notifications",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PendingAmount",
                table: "Instructors",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalEarnedAmount",
                table: "Instructors",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ApprovedById",
                table: "Courses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Courses",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Courses",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailURL",
                table: "Courses",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "InstructorId",
                table: "CourseDiscounts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admin_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseMarketing",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMarketing", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StudentPayment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StripePaymentID = table.Column<string>(type: "TEXT", nullable: false),
                    ActualAmount = table.Column<double>(type: "REAL", nullable: false),
                    IsDiscounted = table.Column<bool>(type: "INTEGER", nullable: false),
                    DiscountedAmount = table.Column<double>(type: "REAL", nullable: false),
                    PaidAmount = table.Column<double>(type: "REAL", nullable: false),
                    PayingDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CourseDiscountId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentCoursesId = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPayment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StudentPayment_CourseDiscounts_CourseDiscountId",
                        column: x => x.CourseDiscountId,
                        principalTable: "CourseDiscounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentPayment_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentPayment_StudentCourses_StudentCoursesId",
                        column: x => x.StudentCoursesId,
                        principalTable: "StudentCourses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideoComments_CommentById",
                table: "VideoComments",
                column: "CommentById");

            migrationBuilder.CreateIndex(
                name: "IX_VideoComments_CourseVideoId",
                table: "VideoComments",
                column: "CourseVideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_RelatedEntityId",
                table: "Notifications",
                column: "RelatedEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ApprovedById",
                table: "Courses",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDiscounts_InstructorId",
                table: "CourseDiscounts",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_UserId",
                table: "Admin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPayment_CourseDiscountId",
                table: "StudentPayment",
                column: "CourseDiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPayment_CourseId",
                table: "StudentPayment",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPayment_StudentCoursesId",
                table: "StudentPayment",
                column: "StudentCoursesId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDiscounts_Courses_CourseId",
                table: "CourseDiscounts",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDiscounts_Instructors_InstructorId",
                table: "CourseDiscounts",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Admin_ApprovedById",
                table: "Courses",
                column: "ApprovedById",
                principalTable: "Admin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Instructors_InstructorId",
                table: "Courses",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Users_UserId",
                table: "Instructors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_CourseMarketing_RelatedEntityId",
                table: "Notifications",
                column: "RelatedEntityId",
                principalTable: "CourseMarketing",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_CourseVideos_CourseVideoID",
                table: "Notifications",
                column: "CourseVideoID",
                principalTable: "CourseVideos",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_VideoComments_RelatedEntityId",
                table: "Notifications",
                column: "RelatedEntityId",
                principalTable: "VideoComments",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Courses_CourseId",
                table: "StudentCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Student_StudentId",
                table: "StudentCourses",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoComments_CourseVideos_CourseVideoId",
                table: "VideoComments",
                column: "CourseVideoId",
                principalTable: "CourseVideos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoComments_Users_CommentById",
                table: "VideoComments",
                column: "CommentById",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoComments_Users_ReplyToId",
                table: "VideoComments",
                column: "ReplyToId",
                principalTable: "Users",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseDiscounts_Courses_CourseId",
                table: "CourseDiscounts");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseDiscounts_Instructors_InstructorId",
                table: "CourseDiscounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Admin_ApprovedById",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Instructors_InstructorId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Users_UserId",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_CourseMarketing_RelatedEntityId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_CourseVideos_CourseVideoID",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_VideoComments_RelatedEntityId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Courses_CourseId",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Student_StudentId",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoComments_CourseVideos_CourseVideoId",
                table: "VideoComments");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoComments_Users_CommentById",
                table: "VideoComments");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoComments_Users_ReplyToId",
                table: "VideoComments");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "CourseMarketing");

            migrationBuilder.DropTable(
                name: "StudentPayment");

            migrationBuilder.DropIndex(
                name: "IX_VideoComments_CommentById",
                table: "VideoComments");

            migrationBuilder.DropIndex(
                name: "IX_VideoComments_CourseVideoId",
                table: "VideoComments");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_RelatedEntityId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Courses_ApprovedById",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_CourseDiscounts_InstructorId",
                table: "CourseDiscounts");

            migrationBuilder.DropColumn(
                name: "CommentById",
                table: "VideoComments");

            migrationBuilder.DropColumn(
                name: "CourseVideoId",
                table: "VideoComments");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "VideoComments");

            migrationBuilder.DropColumn(
                name: "CourseCompleteDate",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "CourseCompleteProgressPercentage",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "CourseStartDate",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "StudentPaymentId",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "NotificationType",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "RelatedEntityId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "PendingAmount",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "TotalEarnedAmount",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "ApprovedById",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ThumbnailURL",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "CourseDiscounts");

            migrationBuilder.RenameColumn(
                name: "ReplyToId",
                table: "VideoComments",
                newName: "ReplyToID");

            migrationBuilder.RenameIndex(
                name: "IX_VideoComments_ReplyToId",
                table: "VideoComments",
                newName: "IX_VideoComments_ReplyToID");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "StudentCourses",
                newName: "StudentID");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "StudentCourses",
                newName: "CourseID");

            migrationBuilder.RenameColumn(
                name: "LastProgressDate",
                table: "StudentCourses",
                newName: "DateJoined");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourses_StudentId",
                table: "StudentCourses",
                newName: "IX_StudentCourses_StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourses",
                newName: "IX_StudentCourses_CourseID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Notifications",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                newName: "IX_Notifications_UserID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Instructors",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "WithdrawnAmount",
                table: "Instructors",
                newName: "EarnedAmount");

            migrationBuilder.RenameIndex(
                name: "IX_Instructors_UserId",
                table: "Instructors",
                newName: "IX_Instructors_UserID");

            migrationBuilder.RenameColumn(
                name: "InstructorId",
                table: "Courses",
                newName: "InstructorID");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses",
                newName: "IX_Courses_InstructorID");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "CourseDiscounts",
                newName: "CourseID");

            migrationBuilder.RenameIndex(
                name: "IX_CourseDiscounts_CourseId",
                table: "CourseDiscounts",
                newName: "IX_CourseDiscounts_CourseID");

            migrationBuilder.AlterColumn<int>(
                name: "ReplyToID",
                table: "VideoComments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "VideoComments",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseVideoID",
                table: "Notifications",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Notifications",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VideoCommentID",
                table: "Notifications",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Instructors",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CourseProgress",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseID = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentCoursesID = table.Column<int>(type: "INTEGER", nullable: false),
                    LastProgressDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Progress = table.Column<double>(type: "REAL", nullable: false),
                    UserID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseProgress", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CourseProgress_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseProgress_StudentCourses_StudentCoursesID",
                        column: x => x.StudentCoursesID,
                        principalTable: "StudentCourses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseProgress_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseID = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentID = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<double>(type: "REAL", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Payments_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Users_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_VideoCommentID",
                table: "Notifications",
                column: "VideoCommentID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProgress_CourseID",
                table: "CourseProgress",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProgress_StudentCoursesID",
                table: "CourseProgress",
                column: "StudentCoursesID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProgress_UserID",
                table: "CourseProgress",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CourseID",
                table: "Payments",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_StudentID",
                table: "Payments",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDiscounts_Courses_CourseID",
                table: "CourseDiscounts",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Instructors_InstructorID",
                table: "Courses",
                column: "InstructorID",
                principalTable: "Instructors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Users_UserID",
                table: "Instructors",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_CourseVideos_CourseVideoID",
                table: "Notifications",
                column: "CourseVideoID",
                principalTable: "CourseVideos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_UserID",
                table: "Notifications",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_VideoComments_VideoCommentID",
                table: "Notifications",
                column: "VideoCommentID",
                principalTable: "VideoComments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Courses_CourseID",
                table: "StudentCourses",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Users_StudentID",
                table: "StudentCourses",
                column: "StudentID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoComments_CourseVideos_ID",
                table: "VideoComments",
                column: "ID",
                principalTable: "CourseVideos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoComments_Users_ID",
                table: "VideoComments",
                column: "ID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoComments_Users_ReplyToID",
                table: "VideoComments",
                column: "ReplyToID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
