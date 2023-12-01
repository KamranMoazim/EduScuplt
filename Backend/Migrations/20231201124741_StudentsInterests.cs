using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class StudentsInterests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentInterests_Student_StudentId",
                table: "StudentInterests");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentInterests_Users_UserId",
                table: "StudentInterests");

            migrationBuilder.DropIndex(
                name: "IX_StudentInterests_UserId",
                table: "StudentInterests");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "StudentInterests");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "StudentInterests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentInterests_Student_StudentId",
                table: "StudentInterests",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentInterests_Student_StudentId",
                table: "StudentInterests");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "StudentInterests",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "StudentInterests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentInterests_UserId",
                table: "StudentInterests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentInterests_Student_StudentId",
                table: "StudentInterests",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentInterests_Users_UserId",
                table: "StudentInterests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
