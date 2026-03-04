using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Tasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProjectEntityUserEntity",
                columns: table => new
                {
                    ProjectsId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEntityUserEntity", x => new { x.ProjectsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ProjectEntityUserEntity_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectEntityUserEntity_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskEntityUserEntity",
                columns: table => new
                {
                    TasksId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskEntityUserEntity", x => new { x.TasksId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_TaskEntityUserEntity_Tasks_TasksId",
                        column: x => x.TasksId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskEntityUserEntity_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEntityUserEntity_UsersId",
                table: "ProjectEntityUserEntity",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskEntityUserEntity_UsersId",
                table: "TaskEntityUserEntity",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "ProjectEntityUserEntity");

            migrationBuilder.DropTable(
                name: "TaskEntityUserEntity");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Tasks");

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
    }
}
