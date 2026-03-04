using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class FinalizedVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserSurname",
                table: "Users",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "UserPassword",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "TaskType",
                table: "Tasks",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "TaskStatus",
                table: "Tasks",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "TaskName",
                table: "Tasks",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "ProjectStatus",
                table: "Projects",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "ProjectName",
                table: "Projects",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ProjectDescription",
                table: "Projects",
                newName: "Description");

            migrationBuilder.AddColumn<int>(
                name: "ProjectEntityId",
                table: "Users",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProjectEntityId",
                table: "Users",
                column: "ProjectEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Projects_ProjectEntityId",
                table: "Users",
                column: "ProjectEntityId",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Projects_ProjectEntityId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ProjectEntityId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProjectEntityId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Users",
                newName: "UserSurname");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "UserPassword");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "UserEmail");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Tasks",
                newName: "TaskStatus");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tasks",
                newName: "TaskType");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Tasks",
                newName: "TaskName");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Projects",
                newName: "ProjectStatus");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Projects",
                newName: "ProjectName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Projects",
                newName: "ProjectDescription");
        }
    }
}
