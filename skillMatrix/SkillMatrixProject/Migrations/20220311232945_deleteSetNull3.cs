using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillMatrixProject.Migrations
{
    public partial class deleteSetNull3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ContractStatuses_ContractStatusId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmploymentStatuses_EmploymentStatusId",
                table: "Employees");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_ContractStatuses_ContractStatusId",
                table: "Employees",
                column: "ContractStatusId",
                principalTable: "ContractStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmploymentStatuses_EmploymentStatusId",
                table: "Employees",
                column: "EmploymentStatusId",
                principalTable: "EmploymentStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ContractStatuses_ContractStatusId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmploymentStatuses_EmploymentStatusId",
                table: "Employees");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_ContractStatuses_ContractStatusId",
                table: "Employees",
                column: "ContractStatusId",
                principalTable: "ContractStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmploymentStatuses_EmploymentStatusId",
                table: "Employees",
                column: "EmploymentStatusId",
                principalTable: "EmploymentStatuses",
                principalColumn: "Id");
        }
    }
}
