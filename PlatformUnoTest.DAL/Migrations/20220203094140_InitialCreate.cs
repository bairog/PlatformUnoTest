using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlatformUnoTest.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ParentDepartmentId = table.Column<long>(type: "INTEGER", nullable: true),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Departments_ParentDepartmentId",
                        column: x => x.ParentDepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.Sql("CREATE TRIGGER UpdateDepartmentsVersion AFTER UPDATE ON Departments " +
               "BEGIN UPDATE Departments SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.CreateTable(
                name: "InputDevices",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SystemName = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    ReferenceName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputDevices", x => x.Id);
                });

            migrationBuilder.Sql("CREATE TRIGGER UpdateInputDevicesVersion AFTER UPDATE ON InputDevices " +
               "BEGIN UPDATE InputDevices SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.CreateTable(
                name: "ModuleTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ModuleTypeApplicability = table.Column<int>(type: "INTEGER", nullable: false),
                    IsMandatory = table.Column<bool>(type: "INTEGER", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleTypes", x => x.Id);
                });

            migrationBuilder.Sql("CREATE TRIGGER UpdateModuleTypesVersion AFTER UPDATE ON ModuleTypes " +
               "BEGIN UPDATE ModuleTypes SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.CreateTable(
                name: "PlaneTypeGroups",
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
                    table.PrimaryKey("PK_PlaneTypeGroups", x => x.Id);
                });

            migrationBuilder.Sql("CREATE TRIGGER UpdatePlaneTypeGroupsVersion AFTER UPDATE ON PlaneTypeGroups " +
               "BEGIN UPDATE PlaneTypeGroups SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.Sql("CREATE TRIGGER UpdatePositionsVersion AFTER UPDATE ON Positions " +
               "BEGIN UPDATE Positions SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.Sql("CREATE TRIGGER UpdateRolesVersion AFTER UPDATE ON Roles " +
               "BEGIN UPDATE Roles SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.CreateTable(
                name: "TaskBases",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SystemName = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    ReferenceName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Language = table.Column<int>(type: "INTEGER", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskBases", x => x.Id);
                });

            migrationBuilder.Sql("CREATE TRIGGER UpdateTaskBasesVersion AFTER UPDATE ON TaskBases " +
               "BEGIN UPDATE TaskBases SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.CreateTable(
                name: "TaskLinkTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskLinkTypes", x => x.Id);
                });

            migrationBuilder.Sql("CREATE TRIGGER UpdateTaskLinkTypesVersion AFTER UPDATE ON TaskLinkTypes " +
               "BEGIN UPDATE TaskLinkTypes SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.CreateTable(
                name: "TaskTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTypes", x => x.Id);
                });

            migrationBuilder.Sql("CREATE TRIGGER UpdateTaskTypesVersion AFTER UPDATE ON TaskTypes " +
               "BEGIN UPDATE TaskTypes SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ModuleTypeId = table.Column<long>(type: "INTEGER", nullable: false),
                    IsEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    SystemName = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modules_ModuleTypes_ModuleTypeId",
                        column: x => x.ModuleTypeId,
                        principalTable: "ModuleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.Sql("CREATE TRIGGER UpdateModulesVersion AFTER UPDATE ON Modules " +
               "BEGIN UPDATE Modules SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.CreateTable(
                name: "PlaneTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlaneTypeGroupId = table.Column<long>(type: "INTEGER", nullable: false),
                    SystemName = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    ReferenceName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaneTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaneTypes_PlaneTypeGroups_PlaneTypeGroupId",
                        column: x => x.PlaneTypeGroupId,
                        principalTable: "PlaneTypeGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.Sql("CREATE TRIGGER UpdatePlaneTypesVersion AFTER UPDATE ON PlaneTypes " +
               "BEGIN UPDATE PlaneTypes SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Patronymic = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Login = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateJoined = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StartDateInCompany = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DismissDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    RoleId = table.Column<long>(type: "INTEGER", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.Sql("CREATE TRIGGER UpdateEmployeesVersion AFTER UPDATE ON Employees " +
               "BEGIN UPDATE Employees SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.CreateTable(
                name: "RegSystems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlaneTypeId = table.Column<long>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegSystems_PlaneTypes_PlaneTypeId",
                        column: x => x.PlaneTypeId,
                        principalTable: "PlaneTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.Sql("CREATE TRIGGER UpdateRegSystemsVersion AFTER UPDATE ON RegSystems " +
               "BEGIN UPDATE RegSystems SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.CreateTable(
                name: "DepartmentsStaff",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DepartmentId = table.Column<long>(type: "INTEGER", nullable: false),
                    EmployeeId = table.Column<long>(type: "INTEGER", nullable: false),
                    PositionId = table.Column<long>(type: "INTEGER", nullable: false),
                    HeadType = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentsStaff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentsStaff_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentsStaff_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentsStaff_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.Sql("CREATE TRIGGER UpdateDepartmentsStaffVersion AFTER UPDATE ON DepartmentsStaff " +
               "BEGIN UPDATE DepartmentsStaff SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.CreateTable(
                name: "Edits",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeId = table.Column<long>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DbContextName = table.Column<string>(type: "TEXT", nullable: false),
                    TableName = table.Column<string>(type: "TEXT", nullable: false),
                    EntityId = table.Column<long>(type: "INTEGER", nullable: false),
                    OriginalState = table.Column<string>(type: "TEXT", nullable: false),
                    ModifiedState = table.Column<string>(type: "TEXT", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edits_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.Sql("CREATE TRIGGER UpdateEditsVersion AFTER UPDATE ON Edits " +
              "BEGIN UPDATE Edits SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.CreateTable(
                name: "PlaneTypeModules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlaneTypeId = table.Column<long>(type: "INTEGER", nullable: false),
                    ModuleId = table.Column<long>(type: "INTEGER", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", nullable: false),
                    IsVerified = table.Column<bool>(type: "INTEGER", nullable: false),
                    VerificatorId = table.Column<long>(type: "INTEGER", nullable: true),
                    VerificationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaneTypeModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaneTypeModules_Employees_VerificatorId",
                        column: x => x.VerificatorId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlaneTypeModules_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaneTypeModules_PlaneTypes_PlaneTypeId",
                        column: x => x.PlaneTypeId,
                        principalTable: "PlaneTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.Sql("CREATE TRIGGER UpdatePlaneTypeModulesVersion AFTER UPDATE ON PlaneTypeModules " +
              "BEGIN UPDATE PlaneTypeModules SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.CreateTable(
                name: "TaskBaseModules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TaskBaseId = table.Column<long>(type: "INTEGER", nullable: false),
                    ModuleId = table.Column<long>(type: "INTEGER", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0),
                    IsVerified = table.Column<bool>(type: "INTEGER", nullable: false),
                    VerificatorId = table.Column<long>(type: "INTEGER", nullable: true),
                    VerificationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskBaseModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskBaseModules_Employees_VerificatorId",
                        column: x => x.VerificatorId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaskBaseModules_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskBaseModules_TaskBases_TaskBaseId",
                        column: x => x.TaskBaseId,
                        principalTable: "TaskBases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.Sql("CREATE TRIGGER UpdateTaskBaseModulesVersion AFTER UPDATE ON TaskBaseModules " +
              "BEGIN UPDATE TaskBaseModules SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TaskTypeId = table.Column<long>(type: "INTEGER", nullable: false),
                    EmployeeId = table.Column<long>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    HoursToComplete = table.Column<long>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PlannedEndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActualEndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_TaskTypes_TaskTypeId",
                        column: x => x.TaskTypeId,
                        principalTable: "TaskTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.Sql("CREATE TRIGGER UpdateTasksVersion AFTER UPDATE ON Tasks " +
              "BEGIN UPDATE Tasks SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.CreateTable(
                name: "TechnicalLibraryDocumentGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0),
                    IsVerified = table.Column<bool>(type: "INTEGER", nullable: false),
                    VerificatorId = table.Column<long>(type: "INTEGER", nullable: true),
                    VerificationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalLibraryDocumentGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnicalLibraryDocumentGroups_Employees_VerificatorId",
                        column: x => x.VerificatorId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.Sql("CREATE TRIGGER UpdateTechnicalLibraryDocumentGroupsVersion AFTER UPDATE ON TechnicalLibraryDocumentGroups " +
              "BEGIN UPDATE TechnicalLibraryDocumentGroups SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.CreateTable(
                name: "StorageDeviceGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegSystemId = table.Column<long>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0),
                    IsVerified = table.Column<bool>(type: "INTEGER", nullable: false),
                    VerificatorId = table.Column<long>(type: "INTEGER", nullable: true),
                    VerificationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageDeviceGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorageDeviceGroups_Employees_VerificatorId",
                        column: x => x.VerificatorId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StorageDeviceGroups_RegSystems_RegSystemId",
                        column: x => x.RegSystemId,
                        principalTable: "RegSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.Sql("CREATE TRIGGER UpdateStorageDeviceGroupsVersion AFTER UPDATE ON StorageDeviceGroups " +
              "BEGIN UPDATE StorageDeviceGroups SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.CreateTable(
                name: "StorageDevices",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegSystemId = table.Column<long>(type: "INTEGER", nullable: false),
                    SystemName = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    ReferenceName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Language = table.Column<int>(type: "INTEGER", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageDevices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorageDevices_RegSystems_RegSystemId",
                        column: x => x.RegSystemId,
                        principalTable: "RegSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.Sql("CREATE TRIGGER UpdateStorageDevicesVersion AFTER UPDATE ON StorageDevices " +
              "BEGIN UPDATE StorageDevices SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.CreateTable(
                name: "TaskLinks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TaskLinkTypeId = table.Column<long>(type: "INTEGER", nullable: false),
                    FromId = table.Column<long>(type: "INTEGER", nullable: false),
                    ToId = table.Column<long>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskLinks_TaskLinkTypes_TaskLinkTypeId",
                        column: x => x.TaskLinkTypeId,
                        principalTable: "TaskLinkTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskLinks_Tasks_FromId",
                        column: x => x.FromId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskLinks_Tasks_ToId",
                        column: x => x.ToId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.Sql("CREATE TRIGGER UpdateTaskLinksVersion AFTER UPDATE ON TaskLinks " +
              "BEGIN UPDATE TaskLinks SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.CreateTable(
                name: "TaskWorkHours",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TaskId = table.Column<long>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Hours = table.Column<long>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskWorkHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskWorkHours_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.Sql("CREATE TRIGGER UpdateTaskWorkHoursVersion AFTER UPDATE ON TaskWorkHours " +
              "BEGIN UPDATE TaskWorkHours SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.CreateTable(
                name: "TechnicalLibraryDocuments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TechnicalLibraryDocumentGroupId = table.Column<long>(type: "INTEGER", nullable: false),
                    DbContextName = table.Column<string>(type: "TEXT", nullable: false),
                    TableName = table.Column<string>(type: "TEXT", nullable: false),
                    EntityId = table.Column<long>(type: "INTEGER", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalLibraryDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnicalLibraryDocuments_TechnicalLibraryDocumentGroups_TechnicalLibraryDocumentGroupId",
                        column: x => x.TechnicalLibraryDocumentGroupId,
                        principalTable: "TechnicalLibraryDocumentGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.Sql("CREATE TRIGGER UpdateTechnicalLibraryDocumentsVersion AFTER UPDATE ON TechnicalLibraryDocuments " +
              "BEGIN UPDATE TechnicalLibraryDocuments SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.CreateTable(
                name: "StorageDeviceGroupModules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StorageDeviceGroupId = table.Column<long>(type: "INTEGER", nullable: false),
                    ModuleId = table.Column<long>(type: "INTEGER", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0),
                    IsVerified = table.Column<bool>(type: "INTEGER", nullable: false),
                    VerificatorId = table.Column<long>(type: "INTEGER", nullable: true),
                    VerificationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageDeviceGroupModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorageDeviceGroupModules_Employees_VerificatorId",
                        column: x => x.VerificatorId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StorageDeviceGroupModules_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StorageDeviceGroupModules_StorageDeviceGroups_StorageDeviceGroupId",
                        column: x => x.StorageDeviceGroupId,
                        principalTable: "StorageDeviceGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.Sql("CREATE TRIGGER UpdateStorageDeviceGroupModulesVersion AFTER UPDATE ON StorageDeviceGroupModules " +
              "BEGIN UPDATE StorageDeviceGroupModules SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.CreateTable(
                name: "StorageDeviceGroupTaskBases",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StorageDeviceGroupId = table.Column<long>(type: "INTEGER", nullable: false),
                    TaskBaseId = table.Column<long>(type: "INTEGER", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0),
                    IsVerified = table.Column<bool>(type: "INTEGER", nullable: false),
                    VerificatorId = table.Column<long>(type: "INTEGER", nullable: true),
                    VerificationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageDeviceGroupTaskBases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorageDeviceGroupTaskBases_Employees_VerificatorId",
                        column: x => x.VerificatorId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StorageDeviceGroupTaskBases_StorageDeviceGroups_StorageDeviceGroupId",
                        column: x => x.StorageDeviceGroupId,
                        principalTable: "StorageDeviceGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StorageDeviceGroupTaskBases_TaskBases_TaskBaseId",
                        column: x => x.TaskBaseId,
                        principalTable: "TaskBases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.Sql("CREATE TRIGGER UpdateStorageDeviceGroupTaskBasesVersion AFTER UPDATE ON StorageDeviceGroupTaskBases " +
              "BEGIN UPDATE StorageDeviceGroupTaskBases SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.CreateTable(
                name: "StorageDeviceInputDevices",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StorageDeviceId = table.Column<long>(type: "INTEGER", nullable: false),
                    InputDeviceId = table.Column<long>(type: "INTEGER", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0),
                    IsVerified = table.Column<bool>(type: "INTEGER", nullable: false),
                    VerificatorId = table.Column<long>(type: "INTEGER", nullable: true),
                    VerificationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageDeviceInputDevices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorageDeviceInputDevices_Employees_VerificatorId",
                        column: x => x.VerificatorId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StorageDeviceInputDevices_InputDevices_InputDeviceId",
                        column: x => x.InputDeviceId,
                        principalTable: "InputDevices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StorageDeviceInputDevices_StorageDevices_StorageDeviceId",
                        column: x => x.StorageDeviceId,
                        principalTable: "StorageDevices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.Sql("CREATE TRIGGER UpdateStorageDeviceInputDevicesVersion AFTER UPDATE ON StorageDeviceInputDevices " +
              "BEGIN UPDATE StorageDeviceInputDevices SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.CreateTable(
                name: "StorageDeviceModules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StorageDeviceId = table.Column<long>(type: "INTEGER", nullable: false),
                    ModuleId = table.Column<long>(type: "INTEGER", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0),
                    IsVerified = table.Column<bool>(type: "INTEGER", nullable: false),
                    VerificatorId = table.Column<long>(type: "INTEGER", nullable: true),
                    VerificationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageDeviceModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorageDeviceModules_Employees_VerificatorId",
                        column: x => x.VerificatorId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StorageDeviceModules_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StorageDeviceModules_StorageDevices_StorageDeviceId",
                        column: x => x.StorageDeviceId,
                        principalTable: "StorageDevices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.Sql("CREATE TRIGGER UpdateStorageDeviceModulesVersion AFTER UPDATE ON StorageDeviceModules " +
              "BEGIN UPDATE StorageDeviceModules SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.CreateTable(
                name: "StorageDeviceStorageDeviceGroup",
                columns: table => new
                {
                    StorageDeviceGroupsId = table.Column<long>(type: "INTEGER", nullable: false),
                    StorageDevicesId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageDeviceStorageDeviceGroup", x => new { x.StorageDeviceGroupsId, x.StorageDevicesId });
                    table.ForeignKey(
                        name: "FK_StorageDeviceStorageDeviceGroup_StorageDeviceGroups_StorageDeviceGroupsId",
                        column: x => x.StorageDeviceGroupsId,
                        principalTable: "StorageDeviceGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StorageDeviceStorageDeviceGroup_StorageDevices_StorageDevicesId",
                        column: x => x.StorageDevicesId,
                        principalTable: "StorageDevices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.Sql("CREATE TRIGGER UpdateStorageDeviceStorageDeviceGroupVersion AFTER UPDATE ON StorageDeviceStorageDeviceGroup " +
            //  "BEGIN UPDATE StorageDeviceStorageDeviceGroup SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.CreateTable(
                name: "StorageDeviceTaskBases",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StorageDeviceId = table.Column<long>(type: "INTEGER", nullable: false),
                    TaskBaseId = table.Column<long>(type: "INTEGER", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0),
                    IsVerified = table.Column<bool>(type: "INTEGER", nullable: false),
                    VerificatorId = table.Column<long>(type: "INTEGER", nullable: true),
                    VerificationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageDeviceTaskBases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorageDeviceTaskBases_Employees_VerificatorId",
                        column: x => x.VerificatorId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StorageDeviceTaskBases_StorageDevices_StorageDeviceId",
                        column: x => x.StorageDeviceId,
                        principalTable: "StorageDevices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StorageDeviceTaskBases_TaskBases_TaskBaseId",
                        column: x => x.TaskBaseId,
                        principalTable: "TaskBases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.Sql("CREATE TRIGGER UpdateStorageDeviceTaskBasesVersion AFTER UPDATE ON StorageDeviceTaskBases " +
              "BEGIN UPDATE StorageDeviceTaskBases SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.CreateTable(
                name: "StorageDeviceVersions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StorageDeviceId = table.Column<long>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    AnalogParametersCount = table.Column<long>(type: "INTEGER", nullable: false),
                    DescreteCommandsCount = table.Column<long>(type: "INTEGER", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0),
                    IsVerified = table.Column<bool>(type: "INTEGER", nullable: false),
                    VerificatorId = table.Column<long>(type: "INTEGER", nullable: true),
                    VerificationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageDeviceVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorageDeviceVersions_Employees_VerificatorId",
                        column: x => x.VerificatorId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StorageDeviceVersions_StorageDevices_StorageDeviceId",
                        column: x => x.StorageDeviceId,
                        principalTable: "StorageDevices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.Sql("CREATE TRIGGER UpdateStorageDeviceVersionsVersion AFTER UPDATE ON StorageDeviceVersions " +
              "BEGIN UPDATE StorageDeviceVersions SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.CreateTable(
                name: "PlaneTypeGroupTechnicalLibraryDocuments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlaneTypeGroupId = table.Column<long>(type: "INTEGER", nullable: false),
                    TechnicalLibraryDocumentId = table.Column<long>(type: "INTEGER", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0),
                    IsVerified = table.Column<bool>(type: "INTEGER", nullable: false),
                    VerificatorId = table.Column<long>(type: "INTEGER", nullable: true),
                    VerificationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaneTypeGroupTechnicalLibraryDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaneTypeGroupTechnicalLibraryDocuments_Employees_VerificatorId",
                        column: x => x.VerificatorId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlaneTypeGroupTechnicalLibraryDocuments_PlaneTypeGroups_PlaneTypeGroupId",
                        column: x => x.PlaneTypeGroupId,
                        principalTable: "PlaneTypeGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaneTypeGroupTechnicalLibraryDocuments_TechnicalLibraryDocuments_TechnicalLibraryDocumentId",
                        column: x => x.TechnicalLibraryDocumentId,
                        principalTable: "TechnicalLibraryDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.Sql("CREATE TRIGGER UpdatePlaneTypeGroupTechnicalLibraryDocumentsVersion AFTER UPDATE ON PlaneTypeGroupTechnicalLibraryDocuments " +
              "BEGIN UPDATE PlaneTypeGroupTechnicalLibraryDocuments SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.CreateTable(
                name: "StorageDeviceTechnicalLibraryDocuments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StorageDeviceId = table.Column<long>(type: "INTEGER", nullable: false),
                    TechnicalLibraryDocumentId = table.Column<long>(type: "INTEGER", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0),
                    IsVerified = table.Column<bool>(type: "INTEGER", nullable: false),
                    VerificatorId = table.Column<long>(type: "INTEGER", nullable: true),
                    VerificationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageDeviceTechnicalLibraryDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorageDeviceTechnicalLibraryDocuments_Employees_VerificatorId",
                        column: x => x.VerificatorId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StorageDeviceTechnicalLibraryDocuments_StorageDevices_StorageDeviceId",
                        column: x => x.StorageDeviceId,
                        principalTable: "StorageDevices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StorageDeviceTechnicalLibraryDocuments_TechnicalLibraryDocuments_TechnicalLibraryDocumentId",
                        column: x => x.TechnicalLibraryDocumentId,
                        principalTable: "TechnicalLibraryDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.Sql("CREATE TRIGGER UpdateStorageDeviceTechnicalLibraryDocumentsVersion AFTER UPDATE ON StorageDeviceTechnicalLibraryDocuments " +
              "BEGIN UPDATE StorageDeviceTechnicalLibraryDocuments SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.CreateTable(
                name: "TaskBaseTechnicalLibraryDocuments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TaskBaseId = table.Column<long>(type: "INTEGER", nullable: false),
                    TechnicalLibraryDocumentId = table.Column<long>(type: "INTEGER", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0),
                    IsVerified = table.Column<bool>(type: "INTEGER", nullable: false),
                    VerificatorId = table.Column<long>(type: "INTEGER", nullable: true),
                    VerificationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskBaseTechnicalLibraryDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskBaseTechnicalLibraryDocuments_Employees_VerificatorId",
                        column: x => x.VerificatorId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaskBaseTechnicalLibraryDocuments_TaskBases_TaskBaseId",
                        column: x => x.TaskBaseId,
                        principalTable: "TaskBases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskBaseTechnicalLibraryDocuments_TechnicalLibraryDocuments_TechnicalLibraryDocumentId",
                        column: x => x.TechnicalLibraryDocumentId,
                        principalTable: "TechnicalLibraryDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.Sql("CREATE TRIGGER UpdateTaskBaseTechnicalLibraryDocumentsVersion AFTER UPDATE ON TaskBaseTechnicalLibraryDocuments " +
              "BEGIN UPDATE TaskBaseTechnicalLibraryDocuments SET Version = Version + 1 WHERE rowid = NEW.rowid; END;");

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "Name", "ParentDepartmentId" },
                values: new object[] { 1L, "Отдел главного конструктора", "Отдел ГК", null });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "Name", "ParentDepartmentId" },
                values: new object[] { 13L, "Архив и  техническая библиотека", "Архив и  техническая библиотека", null });

            migrationBuilder.InsertData(
                table: "ModuleTypes",
                columns: new[] { "Id", "Description", "IsMandatory", "ModuleTypeApplicability", "Name" },
                values: new object[] { 1L, "Модуль 3D модели", false, 1, "3D модель" });

            migrationBuilder.InsertData(
                table: "ModuleTypes",
                columns: new[] { "Id", "Description", "IsMandatory", "ModuleTypeApplicability", "Name" },
                values: new object[] { 2L, "Модуль траектории", false, 2, "Траектория" });

            migrationBuilder.InsertData(
                table: "ModuleTypes",
                columns: new[] { "Id", "Description", "IsMandatory", "ModuleTypeApplicability", "Name" },
                values: new object[] { 3L, "Модуль панели", false, 2, "Панель" });

            migrationBuilder.InsertData(
                table: "ModuleTypes",
                columns: new[] { "Id", "Description", "IsMandatory", "ModuleTypeApplicability", "Name" },
                values: new object[] { 4L, "Задание по-умолчанию", true, 2, "Задание по-умолчанию" });

            migrationBuilder.InsertData(
                table: "ModuleTypes",
                columns: new[] { "Id", "Description", "IsMandatory", "ModuleTypeApplicability", "Name" },
                values: new object[] { 5L, "Обзорное задание", true, 2, "Обзорное задание" });

            migrationBuilder.InsertData(
                table: "ModuleTypes",
                columns: new[] { "Id", "Description", "IsMandatory", "ModuleTypeApplicability", "Name" },
                values: new object[] { 6L, "Скрипт LUA", false, 3, "Скрипт LUA" });

            migrationBuilder.InsertData(
                table: "ModuleTypes",
                columns: new[] { "Id", "Description", "IsMandatory", "ModuleTypeApplicability", "Name" },
                values: new object[] { 7L, "Модуль посадки", false, 3, "Модуль посадки" });

            migrationBuilder.InsertData(
                table: "ModuleTypes",
                columns: new[] { "Id", "Description", "IsMandatory", "ModuleTypeApplicability", "Name" },
                values: new object[] { 8L, "Модуль отчётов", false, 3, "Отчёт" });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1L, null, "Главный конструктор" });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2L, null, "Главный конструктор по ПО" });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3L, null, "Зам. главного конструктора по АО" });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 4L, null, "Зам. главного конструктора по ПО" });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 5L, null, "Начальник отдела" });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 6L, null, "Начальник сектора" });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 7L, null, "Инженер-программист" });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 8L, null, "Конструктор" });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 9L, null, "Ведущий конструктор" });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 10L, null, "Программист" });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 11L, null, "Ведущий программист" });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 12L, null, "Ведущий специалист" });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 13L, null, "Библиотекарь" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name", "Type" },
                values: new object[] { 1L, "Администратор БД Планов и технической библиотеки", "Администратор БД Планов и технической библиотеки", 1 });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name", "Type" },
                values: new object[] { 2L, "Администратор БД Планов", "Администратор БД Планов", 2 });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name", "Type" },
                values: new object[] { 3L, "Обычный сотрудник", "Сотрудник", 3 });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name", "Type" },
                values: new object[] { 4L, "Администратор технической библиотеки - может редактировать", "Администратор технической библиотеки", 4 });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name", "Type" },
                values: new object[] { 5L, "Пользователь технической библиотеки - может просматривать", "Пользователь технической библиотеки", 5 });

            migrationBuilder.InsertData(
                table: "TaskLinkTypes",
                columns: new[] { "Id", "Description", "Name", "Type" },
                values: new object[] { 1L, "Связь \"родитель - потомок\" (задача - подзадача)", "Задача - подзадача", 1 });

            migrationBuilder.InsertData(
                table: "TaskLinkTypes",
                columns: new[] { "Id", "Description", "Name", "Type" },
                values: new object[] { 2L, "Связь \"блокировка\" (задача блокирует выполнение другой)", "Блокировка", 2 });

            migrationBuilder.InsertData(
                table: "TaskTypes",
                columns: new[] { "Id", "Description", "Name", "Type" },
                values: new object[] { 1L, "Раработка нового", "Разработка", 1 });

            migrationBuilder.InsertData(
                table: "TaskTypes",
                columns: new[] { "Id", "Description", "Name", "Type" },
                values: new object[] { 2L, "Корректировка уже имеющегося", "Корректировка", 2 });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "Name", "ParentDepartmentId" },
                values: new object[] { 2L, "Отдел зам. главного конструктора по АО", "Отдел зам. ГК по АО", 1L });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "Name", "ParentDepartmentId" },
                values: new object[] { 3L, "Отдел зам. главного конструктора по ПО", "Отдел зам. ГК по ПО", 1L });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "Name", "ParentDepartmentId" },
                values: new object[] { 4L, "Отдел главного конструктора (НИО-40)", "Отдел главного конструктора (НИО-40)", 1L });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateJoined", "Description", "DismissDate", "Email", "Guid", "Login", "Name", "Patronymic", "RoleId", "StartDateInCompany", "Surname" },
                values: new object[] { 1L, new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Leo@Topaz1.local", new Guid("94a0e648-ed0b-47df-b11b-d68d89c744b2"), "Leo", "Алексей", "Александрович", 1L, new DateTime(2006, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Леонович" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateJoined", "Description", "DismissDate", "Email", "Guid", "Login", "Name", "Patronymic", "RoleId", "StartDateInCompany", "Surname" },
                values: new object[] { 2L, new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "sorokin@Topaz1.local", new Guid("f7b08f32-b7e3-46b3-b302-18b2d591136b"), "sorokin", "Кирилл", "Алексеевич", 1L, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Сорокин" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateJoined", "Description", "DismissDate", "Email", "Guid", "Login", "Name", "Patronymic", "RoleId", "StartDateInCompany", "Surname" },
                values: new object[] { 3L, new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "luba@Topaz1.local", new Guid("2febcbd2-46bb-40c7-8c36-9707c0149334"), "luba", "Люба", "", 4L, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Балашова" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateJoined", "Description", "DismissDate", "Email", "Guid", "Login", "Name", "Patronymic", "RoleId", "StartDateInCompany", "Surname" },
                values: new object[] { 4L, new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "parshina@Topaz1.local", new Guid("77e73cc1-700a-4d1a-a052-ba8f099bda53"), "Паршина", "Татьяна", "Олеговна", 4L, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Паршина" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateJoined", "Description", "DismissDate", "Email", "Guid", "Login", "Name", "Patronymic", "RoleId", "StartDateInCompany", "Surname" },
                values: new object[] { 5L, new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "sm_maria@Topaz1.local", new Guid("dc4f6a07-1187-44d5-a449-d90587578ab3"), "sm_maria", "Мария", "Егоровна", 4L, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Смыкова" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateJoined", "Description", "DismissDate", "Email", "Guid", "Login", "Name", "Patronymic", "RoleId", "StartDateInCompany", "Surname" },
                values: new object[] { 6L, new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "kojenkov@Topaz1.local", new Guid("2b2e789e-0bda-4a04-b717-98d630fb71b7"), "kojenkov", "Леонид", "", 2L, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Коженков" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateJoined", "Description", "DismissDate", "Email", "Guid", "Login", "Name", "Patronymic", "RoleId", "StartDateInCompany", "Surname" },
                values: new object[] { 7L, new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "voshikov@Topaz1.local", new Guid("10fc1303-faac-4ec1-8791-7c3b059a49ee"), "voshikov", "Сергей", "Викторович", 2L, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Вощиков" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateJoined", "Description", "DismissDate", "Email", "Guid", "Login", "Name", "Patronymic", "RoleId", "StartDateInCompany", "Surname" },
                values: new object[] { 8L, new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "alekseev@Topaz1.local", new Guid("5727587c-65d5-4937-b609-0630f2830aa3"), "alekseev", "Сергей", "Викторович", 2L, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Алексеев" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateJoined", "Description", "DismissDate", "Email", "Guid", "Login", "Name", "Patronymic", "RoleId", "StartDateInCompany", "Surname" },
                values: new object[] { 9L, new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "hokum@Topaz1.local", new Guid("3146a151-8e20-43df-84b1-ed85ccbbeaaf"), "hokum", "Игорь", "Олегович", 2L, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Булла" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateJoined", "Description", "DismissDate", "Email", "Guid", "Login", "Name", "Patronymic", "RoleId", "StartDateInCompany", "Surname" },
                values: new object[] { 10L, new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "konyahina@Topaz1.local", new Guid("2f53c79e-9483-4674-961d-c7847fef80e0"), "konyahina", "Валентина", "Олеговна", 2L, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Осинцева" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateJoined", "Description", "DismissDate", "Email", "Guid", "Login", "Name", "Patronymic", "RoleId", "StartDateInCompany", "Surname" },
                values: new object[] { 11L, new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "sergeev@Topaz1.local", new Guid("bee0cfec-662e-49b7-b51f-6af90ed506a0"), "sergeev", "Андрей", "Вадимович", 2L, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Сергеев" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateJoined", "Description", "DismissDate", "Email", "Guid", "Login", "Name", "Patronymic", "RoleId", "StartDateInCompany", "Surname" },
                values: new object[] { 12L, new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "gera@Topaz1.local", new Guid("6192803b-9728-40a4-bd99-b65e83fdffe7"), "gera", "Александр", "", 1L, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Неумыывакин" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "Name", "ParentDepartmentId" },
                values: new object[] { 5L, "Отдел разработки алгоритмического обеспечения (НИО-10)", "ОРАО (НИО-10)", 2L });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "Name", "ParentDepartmentId" },
                values: new object[] { 10L, "Отдел разработки программного обеспечения (НИО-20)", "ОРПО (НИО-20)", 3L });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "Name", "ParentDepartmentId" },
                values: new object[] { 12L, "Отдел разработки перспективного программного обеспечения (НИО-30)", "ОРППО (НИО-30)", 3L });

            migrationBuilder.InsertData(
                table: "DepartmentsStaff",
                columns: new[] { "Id", "DepartmentId", "EmployeeId", "EndDate", "HeadType", "PositionId", "StartDate" },
                values: new object[] { 1L, 2L, 6L, null, 1, 3L, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "DepartmentsStaff",
                columns: new[] { "Id", "DepartmentId", "EmployeeId", "EndDate", "HeadType", "PositionId", "StartDate" },
                values: new object[] { 9L, 13L, 3L, null, 1, 5L, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "DepartmentsStaff",
                columns: new[] { "Id", "DepartmentId", "EmployeeId", "EndDate", "HeadType", "PositionId", "StartDate" },
                values: new object[] { 10L, 13L, 4L, null, 4, 12L, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "DepartmentsStaff",
                columns: new[] { "Id", "DepartmentId", "EmployeeId", "EndDate", "HeadType", "PositionId", "StartDate" },
                values: new object[] { 11L, 13L, 5L, null, 4, 13L, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "Name", "ParentDepartmentId" },
                values: new object[] { 6L, "Сектор БУР самолетов (сектор 101)", "Сектор БУР самолетов (сектор 101)", 5L });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "Name", "ParentDepartmentId" },
                values: new object[] { 7L, "Сектор БУР вертолетов (сектор 102)", "Сектор БУР вертолетов (сектор 102)", 5L });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "Name", "ParentDepartmentId" },
                values: new object[] { 8L, "Сектор диагностики (сектор 103)", "Сектор диагностики (сектор 103)", 5L });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "Name", "ParentDepartmentId" },
                values: new object[] { 9L, "Сектор перспективных разработок (сектор 104)", "Сектор перспективных разработок (сектор 104)", 5L });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "Name", "ParentDepartmentId" },
                values: new object[] { 11L, "Сектор сборки и тестирования программного обеспечения (сектор 201)", "Сектор сборки и тестирования ПО (сектор 201)", 10L });

            migrationBuilder.InsertData(
                table: "DepartmentsStaff",
                columns: new[] { "Id", "DepartmentId", "EmployeeId", "EndDate", "HeadType", "PositionId", "StartDate" },
                values: new object[] { 2L, 5L, 7L, null, 1, 5L, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "DepartmentsStaff",
                columns: new[] { "Id", "DepartmentId", "EmployeeId", "EndDate", "HeadType", "PositionId", "StartDate" },
                values: new object[] { 8L, 10L, 1L, null, 4, 10L, new DateTime(2006, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "DepartmentsStaff",
                columns: new[] { "Id", "DepartmentId", "EmployeeId", "EndDate", "HeadType", "PositionId", "StartDate" },
                values: new object[] { 12L, 10L, 12L, null, 4, 10L, new DateTime(2006, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "DepartmentsStaff",
                columns: new[] { "Id", "DepartmentId", "EmployeeId", "EndDate", "HeadType", "PositionId", "StartDate" },
                values: new object[] { 3L, 6L, 8L, null, 1, 6L, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "DepartmentsStaff",
                columns: new[] { "Id", "DepartmentId", "EmployeeId", "EndDate", "HeadType", "PositionId", "StartDate" },
                values: new object[] { 4L, 7L, 10L, null, 1, 9L, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "DepartmentsStaff",
                columns: new[] { "Id", "DepartmentId", "EmployeeId", "EndDate", "HeadType", "PositionId", "StartDate" },
                values: new object[] { 5L, 7L, 11L, null, 4, 8L, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "DepartmentsStaff",
                columns: new[] { "Id", "DepartmentId", "EmployeeId", "EndDate", "HeadType", "PositionId", "StartDate" },
                values: new object[] { 6L, 8L, 2L, null, 1, 6L, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "DepartmentsStaff",
                columns: new[] { "Id", "DepartmentId", "EmployeeId", "EndDate", "HeadType", "PositionId", "StartDate" },
                values: new object[] { 7L, 9L, 9L, null, 1, 9L, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Name",
                table: "Departments",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ParentDepartmentId",
                table: "Departments",
                column: "ParentDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentsStaff_DepartmentId",
                table: "DepartmentsStaff",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentsStaff_EmployeeId",
                table: "DepartmentsStaff",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentsStaff_PositionId",
                table: "DepartmentsStaff",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Edits_EmployeeId_Date",
                table: "Edits",
                columns: new[] { "EmployeeId", "Date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Email",
                table: "Employees",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Guid",
                table: "Employees",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Login",
                table: "Employees",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleId",
                table: "Employees",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_InputDevices_SystemName",
                table: "InputDevices",
                column: "SystemName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modules_ModuleTypeId_SystemName_IsEnabled",
                table: "Modules",
                columns: new[] { "ModuleTypeId", "SystemName", "IsEnabled" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModuleTypes_Name",
                table: "ModuleTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlaneTypeGroups_Name",
                table: "PlaneTypeGroups",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlaneTypeGroupTechnicalLibraryDocuments_PlaneTypeGroupId_TechnicalLibraryDocumentId",
                table: "PlaneTypeGroupTechnicalLibraryDocuments",
                columns: new[] { "PlaneTypeGroupId", "TechnicalLibraryDocumentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlaneTypeGroupTechnicalLibraryDocuments_TechnicalLibraryDocumentId",
                table: "PlaneTypeGroupTechnicalLibraryDocuments",
                column: "TechnicalLibraryDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaneTypeGroupTechnicalLibraryDocuments_VerificatorId",
                table: "PlaneTypeGroupTechnicalLibraryDocuments",
                column: "VerificatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaneTypeModules_ModuleId",
                table: "PlaneTypeModules",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaneTypeModules_PlaneTypeId_ModuleId",
                table: "PlaneTypeModules",
                columns: new[] { "PlaneTypeId", "ModuleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlaneTypeModules_VerificatorId",
                table: "PlaneTypeModules",
                column: "VerificatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaneTypes_PlaneTypeGroupId",
                table: "PlaneTypes",
                column: "PlaneTypeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaneTypes_SystemName",
                table: "PlaneTypes",
                column: "SystemName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Positions_Name",
                table: "Positions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegSystems_PlaneTypeId_Name",
                table: "RegSystems",
                columns: new[] { "PlaneTypeId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Type",
                table: "Roles",
                column: "Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StorageDeviceGroupModules_ModuleId",
                table: "StorageDeviceGroupModules",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageDeviceGroupModules_StorageDeviceGroupId_ModuleId",
                table: "StorageDeviceGroupModules",
                columns: new[] { "StorageDeviceGroupId", "ModuleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StorageDeviceGroupModules_VerificatorId",
                table: "StorageDeviceGroupModules",
                column: "VerificatorId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageDeviceGroups_Name",
                table: "StorageDeviceGroups",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StorageDeviceGroups_RegSystemId",
                table: "StorageDeviceGroups",
                column: "RegSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageDeviceGroups_VerificatorId",
                table: "StorageDeviceGroups",
                column: "VerificatorId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageDeviceGroupTaskBases_StorageDeviceGroupId_TaskBaseId",
                table: "StorageDeviceGroupTaskBases",
                columns: new[] { "StorageDeviceGroupId", "TaskBaseId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StorageDeviceGroupTaskBases_TaskBaseId",
                table: "StorageDeviceGroupTaskBases",
                column: "TaskBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageDeviceGroupTaskBases_VerificatorId",
                table: "StorageDeviceGroupTaskBases",
                column: "VerificatorId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageDeviceInputDevices_InputDeviceId",
                table: "StorageDeviceInputDevices",
                column: "InputDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageDeviceInputDevices_StorageDeviceId_InputDeviceId",
                table: "StorageDeviceInputDevices",
                columns: new[] { "StorageDeviceId", "InputDeviceId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StorageDeviceInputDevices_VerificatorId",
                table: "StorageDeviceInputDevices",
                column: "VerificatorId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageDeviceModules_ModuleId",
                table: "StorageDeviceModules",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageDeviceModules_StorageDeviceId_ModuleId",
                table: "StorageDeviceModules",
                columns: new[] { "StorageDeviceId", "ModuleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StorageDeviceModules_VerificatorId",
                table: "StorageDeviceModules",
                column: "VerificatorId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageDevices_RegSystemId",
                table: "StorageDevices",
                column: "RegSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageDevices_SystemName_Language",
                table: "StorageDevices",
                columns: new[] { "SystemName", "Language" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StorageDeviceStorageDeviceGroup_StorageDevicesId",
                table: "StorageDeviceStorageDeviceGroup",
                column: "StorageDevicesId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageDeviceTaskBases_StorageDeviceId_TaskBaseId",
                table: "StorageDeviceTaskBases",
                columns: new[] { "StorageDeviceId", "TaskBaseId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StorageDeviceTaskBases_TaskBaseId",
                table: "StorageDeviceTaskBases",
                column: "TaskBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageDeviceTaskBases_VerificatorId",
                table: "StorageDeviceTaskBases",
                column: "VerificatorId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageDeviceTechnicalLibraryDocuments_StorageDeviceId_TechnicalLibraryDocumentId",
                table: "StorageDeviceTechnicalLibraryDocuments",
                columns: new[] { "StorageDeviceId", "TechnicalLibraryDocumentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StorageDeviceTechnicalLibraryDocuments_TechnicalLibraryDocumentId",
                table: "StorageDeviceTechnicalLibraryDocuments",
                column: "TechnicalLibraryDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageDeviceTechnicalLibraryDocuments_VerificatorId",
                table: "StorageDeviceTechnicalLibraryDocuments",
                column: "VerificatorId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageDeviceVersions_StorageDeviceId_Name",
                table: "StorageDeviceVersions",
                columns: new[] { "StorageDeviceId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StorageDeviceVersions_VerificatorId",
                table: "StorageDeviceVersions",
                column: "VerificatorId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskBaseModules_ModuleId",
                table: "TaskBaseModules",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskBaseModules_TaskBaseId_ModuleId",
                table: "TaskBaseModules",
                columns: new[] { "TaskBaseId", "ModuleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskBaseModules_VerificatorId",
                table: "TaskBaseModules",
                column: "VerificatorId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskBases_SystemName_Language",
                table: "TaskBases",
                columns: new[] { "SystemName", "Language" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskBaseTechnicalLibraryDocuments_TaskBaseId_TechnicalLibraryDocumentId",
                table: "TaskBaseTechnicalLibraryDocuments",
                columns: new[] { "TaskBaseId", "TechnicalLibraryDocumentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskBaseTechnicalLibraryDocuments_TechnicalLibraryDocumentId",
                table: "TaskBaseTechnicalLibraryDocuments",
                column: "TechnicalLibraryDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskBaseTechnicalLibraryDocuments_VerificatorId",
                table: "TaskBaseTechnicalLibraryDocuments",
                column: "VerificatorId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskLinks_FromId_ToId",
                table: "TaskLinks",
                columns: new[] { "FromId", "ToId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskLinks_TaskLinkTypeId",
                table: "TaskLinks",
                column: "TaskLinkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskLinks_ToId",
                table: "TaskLinks",
                column: "ToId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskLinkTypes_Type",
                table: "TaskLinkTypes",
                column: "Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_EmployeeId",
                table: "Tasks",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_StartDate_Name",
                table: "Tasks",
                columns: new[] { "StartDate", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskTypeId",
                table: "Tasks",
                column: "TaskTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskTypes_Type",
                table: "TaskTypes",
                column: "Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskWorkHours_TaskId_Date",
                table: "TaskWorkHours",
                columns: new[] { "TaskId", "Date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalLibraryDocumentGroups_Name",
                table: "TechnicalLibraryDocumentGroups",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalLibraryDocumentGroups_VerificatorId",
                table: "TechnicalLibraryDocumentGroups",
                column: "VerificatorId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalLibraryDocuments_DbContextName_TableName_EntityId",
                table: "TechnicalLibraryDocuments",
                columns: new[] { "DbContextName", "TableName", "EntityId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalLibraryDocuments_TechnicalLibraryDocumentGroupId",
                table: "TechnicalLibraryDocuments",
                column: "TechnicalLibraryDocumentGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentsStaff");

            migrationBuilder.DropTable(
                name: "Edits");

            migrationBuilder.DropTable(
                name: "PlaneTypeGroupTechnicalLibraryDocuments");

            migrationBuilder.DropTable(
                name: "PlaneTypeModules");

            migrationBuilder.DropTable(
                name: "StorageDeviceGroupModules");

            migrationBuilder.DropTable(
                name: "StorageDeviceGroupTaskBases");

            migrationBuilder.DropTable(
                name: "StorageDeviceInputDevices");

            migrationBuilder.DropTable(
                name: "StorageDeviceModules");

            migrationBuilder.DropTable(
                name: "StorageDeviceStorageDeviceGroup");

            migrationBuilder.DropTable(
                name: "StorageDeviceTaskBases");

            migrationBuilder.DropTable(
                name: "StorageDeviceTechnicalLibraryDocuments");

            migrationBuilder.DropTable(
                name: "StorageDeviceVersions");

            migrationBuilder.DropTable(
                name: "TaskBaseModules");

            migrationBuilder.DropTable(
                name: "TaskBaseTechnicalLibraryDocuments");

            migrationBuilder.DropTable(
                name: "TaskLinks");

            migrationBuilder.DropTable(
                name: "TaskWorkHours");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "InputDevices");

            migrationBuilder.DropTable(
                name: "StorageDeviceGroups");

            migrationBuilder.DropTable(
                name: "StorageDevices");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "TaskBases");

            migrationBuilder.DropTable(
                name: "TechnicalLibraryDocuments");

            migrationBuilder.DropTable(
                name: "TaskLinkTypes");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "RegSystems");

            migrationBuilder.DropTable(
                name: "ModuleTypes");

            migrationBuilder.DropTable(
                name: "TechnicalLibraryDocumentGroups");

            migrationBuilder.DropTable(
                name: "TaskTypes");

            migrationBuilder.DropTable(
                name: "PlaneTypes");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "PlaneTypeGroups");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
