using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedInterests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterestsUser");

            migrationBuilder.CreateTable(
                name: "StudentInterests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    InterestId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentInterests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentInterests_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentInterests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentInterests_InterestId",
                table: "StudentInterests",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInterests_UserId",
                table: "StudentInterests",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentInterests");

            migrationBuilder.CreateTable(
                name: "InterestsUser",
                columns: table => new
                {
                    InterestsID = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestsUser", x => new { x.InterestsID, x.UsersID });
                    table.ForeignKey(
                        name: "FK_InterestsUser_Interests_InterestsID",
                        column: x => x.InterestsID,
                        principalTable: "Interests",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestsUser_Users_UsersID",
                        column: x => x.UsersID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InterestsUser_UsersID",
                table: "InterestsUser",
                column: "UsersID");
        }
    }
}
