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
                new Student{FirstName="Erick",LastName="Kurniawan",EnrollmentDate=DateTime.Parse("2021-12-12")},
                new Student{FirstName="Agus",LastName="Kurniawan",EnrollmentDate=DateTime.Parse("2021-10-12")},
                new Student{FirstName="Peter",LastName="Parker",EnrollmentDate=DateTime.Parse("2021-12-12")},
                new Student{FirstName="Tony",LastName="Stark",EnrollmentDate=DateTime.Parse("2021-12-12")},
                new Student{FirstName="Bruce",LastName="Banner",EnrollmentDate=DateTime.Parse("2021-12-12")},
            };

            foreach(var s in students)
            {
                context.Students.Add(s);
            }

            var courses = new Course[]
            {
                new Course{Title="Cloud Fundamentals",Credits=3},
                new Course{Title="Microservices Architecture",Credits=3},
                new Course{Title="Frontend Programming",Credits=3},
                new Course{Title="Backend RESTful API",Credits=3},
                new Course{Title="Entity Frmework Core",Credits=3}
            };

            foreach(var c in courses)
            {
                context.Courses.Add(c);
            }


        }
    }
}
