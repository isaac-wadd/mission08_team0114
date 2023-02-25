using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace habitsApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "tasks",
                columns: table => new
                {
                    taskID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TaskName = table.Column<string>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: true),
                    Quadrant = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Completed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tasks", x => x.taskID);
                    table.ForeignKey(
                        name: "FK_tasks_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryId", "CategoryDesc" },
                values: new object[] { 1, "Home" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryId", "CategoryDesc" },
                values: new object[] { 2, "School" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryId", "CategoryDesc" },
                values: new object[] { 3, "Work" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryId", "CategoryDesc" },
                values: new object[] { 4, "Church" });

            migrationBuilder.CreateIndex(
                name: "IX_tasks_CategoryId",
                table: "tasks",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tasks");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
