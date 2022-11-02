using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlatformUnoTest.DAL.Migrations
{
    public partial class TaskWorkHourAddActual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Hours",
                table: "TaskWorkHours",
                newName: "PlanHours");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "TaskWorkHours",
                newName: "PlanStartDate");

            migrationBuilder.RenameIndex(
                name: "IX_TaskWorkHours_TaskId_Date",
                table: "TaskWorkHours",
                newName: "IX_TaskWorkHours_TaskId_PlanStartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualDate",
                table: "TaskWorkHours",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ActualHours",
                table: "TaskWorkHours",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PlanEndDate",
                table: "TaskWorkHours",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualDate",
                table: "TaskWorkHours");

            migrationBuilder.DropColumn(
                name: "ActualHours",
                table: "TaskWorkHours");

            migrationBuilder.DropColumn(
                name: "PlanEndDate",
                table: "TaskWorkHours");

            migrationBuilder.RenameColumn(
                name: "PlanStartDate",
                table: "TaskWorkHours",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "PlanHours",
                table: "TaskWorkHours",
                newName: "Hours");

            migrationBuilder.RenameIndex(
                name: "IX_TaskWorkHours_TaskId_PlanStartDate",
                table: "TaskWorkHours",
                newName: "IX_TaskWorkHours_TaskId_Date");
        }
    }
}
