using System;
using System.Collections.Generic;
using ConsoleApp2.Interfaces;

namespace ConsoleApp2.Entities
{
    public class Student : IEntity
    {
        public Student()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        public Guid Id { get; set; }

        public string LastName { get; set; }

        public string FirstMidName { get; set; }

        public System.DateTime EnrollmentDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
