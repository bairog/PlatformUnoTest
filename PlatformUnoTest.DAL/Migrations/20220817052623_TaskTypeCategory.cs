using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlatformUnoTest.DAL.Migrations
{
    public partial class TaskTypeCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskTypeCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTypeCategories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TaskTypeCategories",
                columns: new[] { "Id", "Type", "Name", "Description" },
                values: new object[] { 1L, 1L, "План", "Запланированная работа" });

            migrationBuilder.InsertData(
                table: "TaskTypeCategories",
                columns: new[] { "Id", "Type", "Name", "Description" },
                values: new object[] { 2L, 2L, "Доп", "Дополнительная работа" });

            migrationBuilder.CreateIndex(
                name: "IX_TaskTypeCategories_Name",
                table: "TaskTypeCategories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskTypeCategories_Type",
                table: "TaskTypeCategories",
                column: "Type",
                unique: true);


            migrationBuilder.DropIndex(
                name: "IX_TaskTypes_Type",
                table: "TaskTypes");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "TaskTypes");

            migrationBuilder.CreateIndex(
                name: "IX_TaskTypes_Name",
                table: "TaskTypes",
                column: "Name",
                unique: true);


            migrationBuilder.AddColumn<long>(
                name: "TaskTypeCategoryId",
                table: "Tasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 1L);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskTypeCategoryId",
                table: "Tasks",
                column: "TaskTypeCategoryId");            

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskTypeCategories_TaskTypeCategoryId",
                table: "Tasks",
                column: "TaskTypeCategoryId",
                principalTable: "TaskTypeCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.Sql("CREATE TRIGGER TaskTypeCategoriesVersion AFTER UPDATE ON TaskTypeCategories " +
              "BEGIN UPDATE TaskTypeCategories SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskTypeCategories_TaskTypeCategoryId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "TaskTypeCategories");

            migrationBuilder.DropIndex(
                name: "IX_TaskTypes_Name",
                table: "TaskTypes");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TaskTypeCategoryId",
                table: "Tasks");

            migrationBuilder.DeleteData(
                table: "TaskTypes",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "TaskTypes",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DropColumn(
                name: "TaskTypeCategoryId",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "TaskTypes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TaskTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TaskTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Type",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_TaskTypes_Type",
                table: "TaskTypes",
                column: "Type",
                unique: true);
        }
    }
}
