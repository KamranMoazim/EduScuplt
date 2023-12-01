using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class EverythingSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_CourseVideos_CourseVideoID",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_CourseVideoID",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "CourseVideoID",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "CourseVideos");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "ApprovedById",
                table: "Instructors",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Instructors",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CourseFoldersID",
                table: "CourseVideos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "CourseMarketing",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CourseFolders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FolderName = table.Column<string>(type: "TEXT", nullable: false),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseFolders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CourseFolders_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorPayments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StripePaymentID = table.Column<string>(type: "TEXT", nullable: false),
                    PaidAmount = table.Column<double>(type: "REAL", nullable: false),
                    PayingDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    InstructorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorPayments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InstructorPayments_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_ApprovedById",
                table: "Instructors",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_CourseVideos_CourseFoldersID",
                table: "CourseVideos",
                column: "CourseFoldersID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMarketing_AdminId",
                table: "CourseMarketing",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseFolders_CourseId",
                table: "CourseFolders",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorPayments_InstructorId",
                table: "InstructorPayments",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseMarketing_Admin_AdminId",
                table: "CourseMarketing",
                column: "AdminId",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseMarketing_Admin_AdminId",
                table: "CourseMarketing");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseVideos_CourseFolders_CourseFoldersID",
                table: "CourseVideos");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Admin_ApprovedById",
                table: "Instructors");

            migrationBuilder.DropTable(
                name: "CourseFolders");

            migrationBuilder.DropTable(
                name: "InstructorPayments");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_ApprovedById",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_CourseVideos_CourseFoldersID",
                table: "CourseVideos");

            migrationBuilder.DropIndex(
                name: "IX_CourseMarketing_AdminId",
                table: "CourseMarketing");

            migrationBuilder.DropColumn(
                name: "ApprovedById",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "CourseFoldersID",
                table: "CourseVideos");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "CourseMarketing");

            migrationBuilder.AddColumn<int>(
                name: "CourseVideoID",
                table: "Notifications",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CourseVideos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Courses",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_CourseVideoID",
                table: "Notifications",
                column: "CourseVideoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_CourseVideos_CourseVideoID",
                table: "Notifications",
                column: "CourseVideoID",
                principalTable: "CourseVideos",
                principalColumn: "ID");
        }
    }
}
