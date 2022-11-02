using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace PlatformUnoTest.DAL
{
    public partial class Employee
    {
        public Int64 Id { get; set; }

        [Required]
        [DisplayName("Фамилия")]
        public string Surname { get; set; }
        [Required]
        [DisplayName("Имя")]
        public string Name { get; set; }
        [DisplayName("Отчество")]
        public string? Patronymic { get; set; }
        [DisplayName("Описание")]
        public String? Description { get; set; }
        [Required]
        [DisplayName("Логин")]
        public string Login { get; set; }
        [Required]
        [DisplayName("Эл. почта")]
        public string Email { get; set; }
        [Required]
        public Guid Guid { get; set; }
        [Required]
        [DisplayName("Дата регистрации")]
        public DateTime DateJoined { get; set; }
        [Required]
        [DisplayName("День начала работы")]
        public DateTime StartDateInCompany { get; set; }
        [DisplayName("Дата увольнения")]
        public DateTime? DismissDate { get; set; }
    }




    public partial class PlanDbContext : DbContext
    {
        public PlanDbContext()
        {
        }

        public PlanDbContext(DbContextOptions<PlanDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new SqliteConnectionStringBuilder();
                builder.DataSource = "DBPlanov.db";
                builder.Pooling = false;
                optionsBuilder.UseSqlite(builder.ToString());                

                // Compiling a query which loads related collections for more than one collection navigation either via 'Include' or through projection 
                //but no 'QuerySplittingBehavior' has been configured. By default Entity Framework will use 'QuerySplittingBehavior.SingleQuery' which 
                //can potentially result in slow query performance. See https://go.microsoft.com/fwlink/?linkid=2134277 for more information. 
                //To identify the query that's triggering this warning call 'ConfigureWarnings(w => w.Throw(RelationalEventId.MultipleCollectionIncludeWarning))'
                optionsBuilder.ConfigureWarnings(w => w.Throw(RelationalEventId.MultipleCollectionIncludeWarning));

                //Entity Framework Core 5 simple logging example
                //optionsBuilder.LogTo(Console.WriteLine);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Email сотрудника в рамках ВСЕЙ БАЗЫ должны быть уникален
            modelBuilder.Entity<Employee>().HasIndex(e => new { e.Email }).IsUnique();

            //Login сотрудника в рамках ВСЕЙ БАЗЫ должны быть уникален
            modelBuilder.Entity<Employee>().HasIndex(e => new { e.Login }).IsUnique();

            //Guid сотрудника в рамках ВСЕЙ БАЗЫ должны быть уникален
            modelBuilder.Entity<Employee>().HasIndex(e => new { e.Guid }).IsUnique();
        }
    }


    public static class StorageSystem
    {
        static StorageSystem()
        {
            using (var context = new PlanDbContext())
            {
                var migrations = context.Database.GetPendingMigrations().ToList();
                if (migrations.Any())
                {
                    var migrator = context.Database.GetService<IMigrator>();
                    foreach (var migration in migrations)
                        migrator.Migrate(migration);
                }
            }
        }

        public static List<Employee> GetAllEmployee()
        {
            using (var context = new PlanDbContext())
            {
                return context.Employees.AsNoTracking().ToList();
            }
        }
    }
}