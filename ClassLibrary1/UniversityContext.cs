using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1
{
    public class UniversityContext : DbContext
    {
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<InstructorEntity> Instructors { get; set; }
        public DbSet<EnrollmentEntity> Enrollments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var path = System.IO.Path.Join(Environment.CurrentDirectory, "university.db");
                optionsBuilder.UseSqlite($"Data Source={path}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konfiguracja relacji
            modelBuilder.Entity<EnrollmentEntity>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<EnrollmentEntity>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId);

            modelBuilder.Entity<CourseEntity>()
                .HasOne(c => c.Instructor)
                .WithMany(i => i.Courses)
                .HasForeignKey(c => c.InstructorId);
        }
    }
}
