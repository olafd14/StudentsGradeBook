using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentsGradeBook.Migrations
{
    /// <inheritdoc />
    public partial class addGroupTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.AddColumn<string>(
                name: "GroupId",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GroupId1",
                table: "Subjects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GroupId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GroupId1",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_GroupId1",
                table: "Subjects",
                column: "GroupId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GroupId1",
                table: "AspNetUsers",
                column: "GroupId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Groups_GroupId1",
                table: "AspNetUsers",
                column: "GroupId1",
                principalTable: "Groups",
                principalColumn: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Groups_GroupId1",
                table: "Subjects",
                column: "GroupId1",
                principalTable: "Groups",
                principalColumn: "GroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Groups_GroupId1",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Groups_GroupId1",
                table: "Subjects");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_GroupId1",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GroupId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "GroupId1",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GroupId1",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });
        }
    }
}
