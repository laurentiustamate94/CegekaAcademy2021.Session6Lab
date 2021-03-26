using System;
using ConsoleApp2.Database;
using ConsoleApp2.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ConsoleApp2.Interfaces;

namespace ConsoleApp2
{
    class Program
    {
        private UniversityContext context;

        public Program(UniversityContext context)
        {
            this.context = context
        }

        static void Main(string[] args)
        {
            context.Database.EnsureCreated();
            context.Database.Migrate();
            

            IRepository<Student> studentRepository = new EntityFrameworkRepository<Student>();
            
            studentRepository.Insert(
                new Student
                {
                    LastName = "Stamate",
                    FirstMidName = "Laurentiu",
                    EnrollmentDate = DateTime.Parse("2021-09-01")
                });

            AddStudent();
            ReadStudent();
            ChangeStudent();
            DeleteStudent();

            context.Dispose();
        }

        private static void AddStudent()
        {
            var context = new UniversityContext();
            try
            {

                var student = new Student
                {
                    LastName = "Stamate",
                    FirstMidName = "Laurentiu",
                    EnrollmentDate = DateTime.Parse("2021-09-01")
                };

                context.Students.Add(student);
                context.SaveChanges();

            }
            finally
            {
                context.Dispose();
            }
        }

        private static void ReadStudent()
        {
            using (var db = new UniversityContext())
            {

                var query = from b in db.Students orderby b.FirstMidName select b;
                Console.WriteLine("All All student in the database:");

                foreach (var item in query)
                {
                    Console.WriteLine(item.FirstMidName + " " + item.LastName);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        private static void ChangeStudent()
        {

            using (var context = new UniversityContext())
            {

                var student = (from d in context.Students
                               where d.FirstMidName == "Laurentiu"
                               select d).Single();
                student.LastName = "Iacob";
                context.SaveChanges();

            }
        }

        private static void DeleteStudent()
        {

            using (var context = new UniversityContext())
            {
                var student = (from d in context.Students where d.FirstMidName == "Laurentiu" select d).Single();
                context.Students.Remove(student);
                context.SaveChanges();
            }
        }
    }
}
