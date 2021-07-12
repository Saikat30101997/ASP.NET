using ForEntityFrameWork.Training.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForEntityFrameWork.Training.Context
{
    public class TrainingDbContext : DbContext , ITrainingDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public TrainingDbContext(string connectionString, string migrationAssemblyName)
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseStudents>()
                .HasKey(cs => new { cs.CourseId, cs.StudentId });

            modelBuilder.Entity<CourseStudents>()
                .HasOne(cs => cs.Course)
                .WithMany(c => c.EnrollStudents)
                .HasForeignKey(cs => cs.CourseId);

            modelBuilder.Entity<CourseStudents>()
                .HasOne(cs => cs.Student)
                .WithMany(s => s.EnrollCourses)
                .HasForeignKey(cs => cs.StudentId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Student> Students { get; set; }
      
    }
}
