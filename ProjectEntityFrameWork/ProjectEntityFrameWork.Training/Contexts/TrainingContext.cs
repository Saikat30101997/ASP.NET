
using Microsoft.EntityFrameworkCore;
using ProjectEntityFrameWork.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEntityFrameWork.Training.Contexts
{
    public class TrainingContext : DbContext, ITrainingContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public TrainingContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)  //fluent api
        {
            //one to many RelationShip
            modelBuilder.Entity<Course>()
                .HasMany(c=>c.Topics)
                .WithOne(t => t.Course);
            //coursestudent er composite primary key creation
            modelBuilder.Entity<CourseStudents>()
                .HasKey(cs => new { cs.CourseId, cs.StudentId });

            //many to many relation
            modelBuilder.Entity<CourseStudents>() //Course er sathe student
                .HasOne(cs=>cs.Course)
                .WithMany(c => c.EnrolledStudents)
                .HasForeignKey(cs => cs.CourseId);

            modelBuilder.Entity<CourseStudents>() //Student er sathe course er
                .HasOne(cs=>cs.Student)
                .WithMany(s => s.EnrolledCourses)
                .HasForeignKey(cs => cs.StudentId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<StockPrice> StockPrices { get; set; }
       
    }
}
