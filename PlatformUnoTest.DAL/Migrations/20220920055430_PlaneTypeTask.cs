using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlatformUnoTest.DAL.Migrations
{
    public partial class PlaneTypeTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlaneTypeTask",
                columns: table => new
                {
                    PlaneTypesId = table.Column<long>(type: "INTEGER", nullable: false),
                    TasksId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaneTypeTask", x => new { x.PlaneTypesId, x.TasksId });
                    table.ForeignKey(
                        name: "FK_PlaneTypeTask_PlaneTypes_PlaneTypesId",
                        column: x => x.PlaneTypesId,
                        principalTable: "PlaneTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaneTypeTask_Tasks_TasksId",
                        column: x => x.TasksId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlaneTypeTask_TasksId",
                table: "PlaneTypeTask",
                column: "TasksId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaneTypeTask");
        }
    }
}
