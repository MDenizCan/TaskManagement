using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class CleanerVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "IsTaskCompleted",
                table: "Tasks",
                newName: "TaskStatus");

            migrationBuilder.RenameColumn(
                name: "isProjectCompleted",
                table: "Projects",
                newName: "ProjectStatus");

            migrationBuilder.RenameColumn(
                name: "ProjectVersion",
                table: "Projects",
                newName: "ProjectDescription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaskStatus",
                table: "Tasks",
                newName: "IsTaskCompleted");

            migrationBuilder.RenameColumn(
                name: "ProjectStatus",
                table: "Projects",
                newName: "isProjectCompleted");

            migrationBuilder.RenameColumn(
                name: "ProjectDescription",
                table: "Projects",
                newName: "ProjectVersion");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserRole",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Tasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Tasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Projects",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Projects",
                type: "TEXT",
                nullable: true);
        }
    }
}
