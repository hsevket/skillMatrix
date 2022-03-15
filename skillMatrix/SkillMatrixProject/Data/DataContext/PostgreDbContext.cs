using Microsoft.EntityFrameworkCore;
using SkillMatrixProject.Models;

namespace skillMatrix.WebAPI.Data.DataContext
{
    public class PostgreDbContext : DbContext
    {
        public PostgreDbContext(DbContextOptions<PostgreDbContext> options)
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
                        .HasOne(e => e.Employee)
                        .WithMany(es => es.Employee_Skills)
                        .HasForeignKey(ei => ei.EmployeeId);





        }
    }
}