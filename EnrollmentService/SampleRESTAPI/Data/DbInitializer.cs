using SampleRESTAPI.Models;
using System;
using System.Linq;

namespace SampleRESTAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Students.Any())
            {
                return;
            }

            var students = new Student[]
            {
                new Student{FirstName="Suzev",LastName="Atsma",EnrollmentDate=DateTime.Now},
                new Student{FirstName="Ridwan",LastName="Hanim",EnrollmentDate=DateTime.Now},
                new Student{FirstName="Yadi",LastName="Sembako",EnrollmentDate=DateTime.Now},          
            };

            foreach (var s in students)
            {
                context.Students.Add(s);
            }

            context.SaveChanges();

            var courses = new Course[]
            {
                new Course{Title="Cloud Fundamentals",Credits=3, Price=9000},
                new Course{Title="Microservices Architecture",Credits=3, Price=8000},
                new Course{Title="Frontend Programming",Credits=3, Price=5000},
                new Course{Title="Backend RESTful API",Credits=3, Price=7000},
                new Course{Title="Entity Frmework Core",Credits=3, Price=6000}
            };

            foreach (var c in courses)
            {
                context.Courses.Add(c);
            }

            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment{StudentID=1,CourseID=1,Grade=1},
                new Enrollment{StudentID=1,CourseID=2,Grade=2},
                new Enrollment{StudentID=1,CourseID=3,Grade=3},
                new Enrollment{StudentID=2,CourseID=1,Grade=1},
                new Enrollment{StudentID=2,CourseID=2,Grade=2},
                new Enrollment{StudentID=2,CourseID=3,Grade=3},
                new Enrollment{StudentID=3,CourseID=1,Grade=1},
                new Enrollment{StudentID=3,CourseID=2,Grade=2},
                new Enrollment{StudentID=3,CourseID=3,Grade=3},
            };

            foreach(var e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
        }
    }
}
