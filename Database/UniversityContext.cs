using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp2.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2.Database
{
    public class UniversityContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDb;Initial Catalog=session_six;");
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<Course> Courses { get; set; }
    }
}
