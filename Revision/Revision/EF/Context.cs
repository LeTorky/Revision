using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revision.EF
{
    public class Context:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourses> StudentCourses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasKey(Std => new { Std.Id, Std.NationalID });
            modelBuilder.Entity<StudentCourses>().HasKey(SC => new { SC.StudentId, SC.CourseId, SC.StudentNationalId });
            modelBuilder.Entity<StudentCourses>().HasOne<Student>(SC => SC.Student).WithMany(S => S.Courses).HasForeignKey(SC => new { SC.StudentId, SC.StudentNationalId });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=TestingEF;Trusted_Connection=True;Connection Timeout=30");
        }
    }
}
