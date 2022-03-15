using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillMatrixProject.Migrations
{
    public partial class deleteSetNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_JobTitles_JobtitleId",
                table: "Employees");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_JobTitles_JobtitleId",
                table: "Employees",
                column: "JobtitleId",
                principalTable: "JobTitles",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_JobTitles_JobtitleId",
                table: "Employees");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_JobTitles_JobtitleId",
                table: "Employees",
                column: "JobtitleId",
                principalTable: "JobTitles",
                principalColumn: "Id");
        }
    }
}
