using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlatformUnoTest.DAL.Migrations
{
    public partial class AddDistributionsAndPlaneTypeModuleDistributions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Distributions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DueDateAO = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Document = table.Column<string>(type: "TEXT", nullable: false),
                    ManagerId = table.Column<long>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distributions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Distributions_Employees_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaneTypeModuleDistributions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlaneTypeModuleId = table.Column<long>(type: "INTEGER", nullable: false),
                    DistributionId = table.Column<long>(type: "INTEGER", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaneTypeModuleDistributions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaneTypeModuleDistributions_Distributions_DistributionId",
                        column: x => x.DistributionId,
                        principalTable: "Distributions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaneTypeModuleDistributions_PlaneTypeModules_PlaneTypeModuleId",
                        column: x => x.PlaneTypeModuleId,
                        principalTable: "PlaneTypeModules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Distributions_DueDate_Document",
                table: "Distributions",
                columns: new[] { "DueDate", "Document" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Distributions_ManagerId",
                table: "Distributions",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaneTypeModuleDistributions_DistributionId_PlaneTypeModuleId",
                table: "PlaneTypeModuleDistributions",
                columns: new[] { "DistributionId", "PlaneTypeModuleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlaneTypeModuleDistributions_PlaneTypeModuleId",
                table: "PlaneTypeModuleDistributions",
                column: "PlaneTypeModuleId");

            migrationBuilder.Sql("CREATE TRIGGER UpdatePlaneTypeTaskVersion AFTER UPDATE ON PlaneTypeTask " +
              "BEGIN UPDATE PlaneTypeTask SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.Sql("CREATE TRIGGER UpdateTasksVersion AFTER UPDATE ON Tasks " +
              "BEGIN UPDATE Tasks SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.Sql("CREATE TRIGGER UpdateTaskTypesVersion AFTER UPDATE ON TaskTypes " +
               "BEGIN UPDATE TaskTypes SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.Sql("CREATE TRIGGER UpdateDistributionsVersion AFTER UPDATE ON Distributions " +
             "BEGIN UPDATE Distributions SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.Sql("CREATE TRIGGER UpdatePlaneTypeModuleDistributionsVersion AFTER UPDATE ON PlaneTypeModuleDistributions " +
             "BEGIN UPDATE PlaneTypeModuleDistributions SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaneTypeModuleDistributions");

            migrationBuilder.DropTable(
                name: "Distributions");
        }
    }
}
