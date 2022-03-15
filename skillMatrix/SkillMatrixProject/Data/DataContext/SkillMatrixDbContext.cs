using Microsoft.EntityFrameworkCore;
using SkillMatrixProject.Models;

namespace skillMatrix.WebAPI.Data.DataContext
{
    public class SkillMatrixDbContext: DbContext 
    {
        public SkillMatrixDbContext(DbContextOptions<SkillMatrixDbContext> options)
            : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<ContractStatus> ContractStatuses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmploymentStatus> EmploymentStatuses { get; set; }
        public DbSet<Jobtitle> JobTitles { get; set; }
        public DbSet<SkillCategory> SkillCategories { get; set; }
        public DbSet<SkillLevel> SkillLevels { get; set; }
        public DbSet<Employee_Skill> Employee_Skills { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee_Skill>()
        .HasKey(table => new { table.EmployeeId, table.SkillId } );

            modelBuilder.Entity<Employee_Skill>()
                        .HasOne(e => e.Employee)
                        .WithMany(es => es.Employee_Skills)
                        .HasForeignKey(ei => ei.EmployeeId);

            modelBuilder.Entity<Employee_Skill>()
                        .HasOne(e => e.Skill)
                        .WithMany(es => es.Employee_Skills)
                        .HasForeignKey(ei => ei.SkillId);

            modelBuilder.Entity<Jobtitle>()
                        .HasMany(j => j.Employees)
                         .WithOne(e => e.Jobtitle)
                         .HasForeignKey(x => x.JobtitleId)
                        .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ContractStatus>()
                        .HasMany(j => j.Employees)
                         .WithOne(e => e.ContractStatus)
                         .HasForeignKey(x => x.ContractStatusId)
                        .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<EmploymentStatus>()
                        .HasMany(j => j.Employees)
                         .WithOne(e => e.EmploymentStatus)
                         .HasForeignKey(x => x.EmploymentStatusId)
                        .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Department>()
                        .HasMany(j => j.Employees)
                         .WithOne(e => e.Department)
                         .HasForeignKey(x => x.DepartmentId)
                        .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
