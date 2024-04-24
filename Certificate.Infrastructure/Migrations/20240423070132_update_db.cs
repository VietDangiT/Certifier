using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Certificate.Infrastructure.Migrations
{
    public partial class update_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "UserInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "mentorSign",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_CourseId",
                table: "UserInfos",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfos_Courses_CourseId",
                table: "UserInfos",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_Courses_CourseId",
                table: "UserInfos");

            migrationBuilder.DropIndex(
                name: "IX_UserInfos_CourseId",
                table: "UserInfos");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "UserInfos");

            migrationBuilder.DropColumn(
                name: "mentorSign",
                table: "Courses");
        }
    }
}
