using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlatformUnoTest.DAL.Migrations
{
    public partial class TaskAreaAndTaskHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AmountOfWork",
                table: "Tasks",
                type: "TEXT",
                nullable: false,
                defaultValue: "");            

            migrationBuilder.CreateTable(
                name: "TaskAreas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskAreas", x => x.Id);
                });

            migrationBuilder.InsertData(
               table: "TaskAreas",
               columns: new[] { "Id", "Name", "Description" },
               values: new object[] { 1L, "БД ПП", "БД ПП" });

            migrationBuilder.InsertData(
               table: "TaskAreas",
               columns: new[] { "Id", "Name", "Description" },
               values: new object[] { 2L, "БД РП", "БД РП" });

            migrationBuilder.InsertData(
               table: "TaskAreas",
               columns: new[] { "Id", "Name", "Description" },
               values: new object[] { 3L, "Модуль Траектория", "Модуль Траектория" });

            migrationBuilder.InsertData(
               table: "TaskAreas",
               columns: new[] { "Id", "Name", "Description" },
               values: new object[] { 4L, "Модуль Приборная панель", "Модуль Приборная панель" });

            migrationBuilder.InsertData(
               table: "TaskAreas",
               columns: new[] { "Id", "Name", "Description" },
               values: new object[] { 5L, "Модуль Стат. отчёты", "Модуль Стат. отчёты" });

            migrationBuilder.InsertData(
               table: "TaskAreas",
               columns: new[] { "Id", "Name", "Description" },
               values: new object[] { 6L, "Модуль Ст. задания", "Модуль Ст. задания" });

            migrationBuilder.InsertData(
               table: "TaskAreas",
               columns: new[] { "Id", "Name", "Description" },
               values: new object[] { 7L, "Модуль Этапы полёта", "Модуль Этапы полёта" });

            migrationBuilder.InsertData(
               table: "TaskAreas",
               columns: new[] { "Id", "Name", "Description" },
               values: new object[] { 8L, "Материалы", "Материалы" });

            migrationBuilder.InsertData(
               table: "TaskAreas",
               columns: new[] { "Id", "Name", "Description" },
               values: new object[] { 9L, "Замечания", "Замечания" });

            migrationBuilder.InsertData(
               table: "TaskAreas",
               columns: new[] { "Id", "Name", "Description" },
               values: new object[] { 10L, "Другое", "Другое" });


            migrationBuilder.AddColumn<long>(
                name: "TaskAreaId",
                table: "Tasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 1L);


            migrationBuilder.CreateTable(
                name: "TaskHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TaskId = table.Column<long>(type: "INTEGER", nullable: false),
                    TaskHistoryType = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskHistory_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskAreaId",
                table: "Tasks",
                column: "TaskAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskAreas_Name",
                table: "TaskAreas",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskHistory_TaskId_Date",
                table: "TaskHistory",
                columns: new[] { "TaskId", "Date" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskAreas_TaskAreaId",
                table: "Tasks",
                column: "TaskAreaId",
                principalTable: "TaskAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.Sql("CREATE TRIGGER TaskAreasVersion AFTER UPDATE ON TaskAreas " +
              "BEGIN UPDATE TaskAreas SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.Sql("CREATE TRIGGER TaskHistoryVersion AFTER UPDATE ON TaskHistory " +
             "BEGIN UPDATE TaskHistory SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskAreas_TaskAreaId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "TaskAreas");

            migrationBuilder.DropTable(
                name: "TaskHistory");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TaskAreaId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "AmountOfWork",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TaskAreaId",
                table: "Tasks");
        }
    }
}
