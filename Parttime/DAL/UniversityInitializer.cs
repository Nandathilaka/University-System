using Parttime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parttime.DAL
{
    public class UniversityInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<UniversityContext>
    {
        protected override void Seed(UniversityContext context)
        {
            var student = new List<Student>
            {
                new Student{FirstMidName="Thilina",LastName="Chamika",EnrollmentDate=DateTime.Parse("2005-09-01") },
                new Student{FirstMidName="Sameera",LastName="Nandathilaka",EnrollmentDate=DateTime.Parse("2007-08-05") },
                new Student{FirstMidName="Hansini",LastName="Indrachapa",EnrollmentDate=DateTime.Parse("2006-01-07") },
                new Student{FirstMidName="Sumana",LastName="Thilaka",EnrollmentDate=DateTime.Parse("1994-01-23") },
                new Student{FirstMidName="Nandawathi",LastName="Nandawathi",EnrollmentDate=DateTime.Parse("2005-12-14") },
                new Student{FirstMidName="Dinusha",LastName="Priyadarshani",EnrollmentDate=DateTime.Parse("2010-08-23") },
                new Student{FirstMidName="Nuwan",LastName="Kumara",EnrollmentDate=DateTime.Parse("1993-08-23") },
                new Student{FirstMidName="Saman",LastName="Kumara",EnrollmentDate=DateTime.Parse("1992-07-03") },

            };
            student.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var course = new List<Course>
            {
                new Course{CourseID=1050,Title="Chemistry",Credits=3},
                new Course{CourseID=4022,Title="Microeconomic",Credits=3},
                new Course{CourseID=4041,Title="Macroeconomic",Credits=3},
                new Course{CourseID=1045,Title="Calculus",Credits=4},
                new Course{CourseID=3141,Title="Trigonometry",Credits=4},
                new Course{CourseID=2021,Title="Composition",Credits=3},
                new Course{CourseID=2042,Title="Literature",Credits=4},
            };
            course.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A },
                new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C },
                new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B },
                new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B },
                new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F },
                new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F },
                new Enrollment{StudentID=3,CourseID=1050, },
                new Enrollment{StudentID=4,CourseID=1050,},
                new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F },
                new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C },
                new Enrollment{StudentID=6,CourseID=1045, },
                new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A },
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();

        }
    }
}