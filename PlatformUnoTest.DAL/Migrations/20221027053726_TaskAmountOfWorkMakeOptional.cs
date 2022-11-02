using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlatformUnoTest.DAL.Migrations
{
    public partial class TaskAmountOfWorkMakeOptional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AmountOfWork",
                table: "Tasks",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Distributions",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            //в миграции 20221004113415_AddDistributionsAndPlaneTypeModuleDistributions ошибочно был создан триггер UpdatePlaneTypeTaskVersion для таблицы PlaneTypeTasks,
            //у которой нет поля Version (т. к. не описана специальная сущность PlaneTypeTask - EF6 создаёт её на лету и двух взаимных коллекций в классах PlaneType и Task)
            migrationBuilder.Sql("DROP TRIGGER UpdatePlaneTypeTaskVersion;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AmountOfWork",
                table: "Tasks",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Distributions",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
