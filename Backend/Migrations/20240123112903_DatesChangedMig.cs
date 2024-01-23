using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class DatesChangedMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StudentInterests",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Student",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Instructors",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Admin",
                newName: "ID");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "VideoComments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "VideoComments",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "VideoComments",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "VideoComments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "VideoComments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Tags",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Tags",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Tags",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Tags",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Tags",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "StudentPayment",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "StudentPayment",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StudentPayment",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "StudentPayment",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "StudentPayment",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "StudentInterests",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "StudentInterests",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StudentInterests",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "StudentInterests",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "StudentInterests",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "StudentCourses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "StudentCourses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StudentCourses",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "StudentCourses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "StudentCourses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Student",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Student",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Student",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Student",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Student",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Notifications",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Notifications",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Notifications",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Notifications",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Notifications",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Interests",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Interests",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Interests",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Interests",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Interests",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Instructors",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Instructors",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Instructors",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Instructors",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Instructors",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "InstructorPayments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "InstructorPayments",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "InstructorPayments",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "InstructorPayments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "InstructorPayments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CourseVideos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "CourseVideos",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CourseVideos",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "CourseVideos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "CourseVideos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Courses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Courses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Courses",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Courses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Courses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CourseMarketing",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "CourseMarketing",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CourseMarketing",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "CourseMarketing",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "CourseMarketing",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CourseFolders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "CourseFolders",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CourseFolders",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "CourseFolders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "CourseFolders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CourseDiscounts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "CourseDiscounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CourseDiscounts",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "CourseDiscounts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "CourseDiscounts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Admin",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Admin",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Admin",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Admin",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Admin",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "VideoComments");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "VideoComments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "VideoComments");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "VideoComments");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "VideoComments");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "StudentPayment");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "StudentPayment");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StudentPayment");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "StudentPayment");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "StudentPayment");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "StudentInterests");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "StudentInterests");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StudentInterests");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "StudentInterests");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "StudentInterests");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "InstructorPayments");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "InstructorPayments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "InstructorPayments");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "InstructorPayments");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "InstructorPayments");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CourseVideos");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "CourseVideos");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CourseVideos");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "CourseVideos");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "CourseVideos");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CourseMarketing");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "CourseMarketing");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CourseMarketing");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "CourseMarketing");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "CourseMarketing");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CourseFolders");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "CourseFolders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CourseFolders");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "CourseFolders");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "CourseFolders");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CourseDiscounts");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "CourseDiscounts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CourseDiscounts");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "CourseDiscounts");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "CourseDiscounts");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Admin");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "StudentInterests",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Student",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Instructors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Admin",
                newName: "Id");
        }
    }
}
