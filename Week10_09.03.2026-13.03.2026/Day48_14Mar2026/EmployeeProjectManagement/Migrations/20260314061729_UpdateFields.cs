using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeProjectManagement.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Departments",
                newName: "TechRequired");

            migrationBuilder.AddColumn<int>(
                name: "TeamSize",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamSize",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "DepartmentName",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "TechRequired",
                table: "Departments",
                newName: "Name");
        }
    }
}
