namespace Parttime.Migrations
{
    using Parttime.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Parttime.DAL.UniversityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //ContextKey = "Parttime.DAL.UniversityContext";
        }

        protected override void Seed(Parttime.DAL.UniversityContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var students = new List<Student>
            {
                new Student {FirstMidname ="Thilina", LastName="Chamika",EnrollmentDate=DateTime.Parse("2018-04-07")  },
                new Student {FirstMidname ="Sameera", LastName="Nandathilaka",EnrollmentDate=DateTime.Parse("2010-05-02")  },
                new Student {FirstMidname ="Hansini", LastName="Indrachapa",EnrollmentDate=DateTime.Parse("2011-01-27")  },
                new Student {FirstMidname ="Sumana", LastName="Thilaka",EnrollmentDate=DateTime.Parse("2009-09-01")  },
                new Student {FirstMidname ="Nuwan", LastName="Chathuranga",EnrollmentDate=DateTime.Parse("2001-02-11")  },
                new Student {FirstMidname ="Amal", LastName="Perera",EnrollmentDate=DateTime.Parse("2008-08-22")  },
                new Student {FirstMidname ="Dinusha", LastName="Samanthi",EnrollmentDate=DateTime.Parse("2016-06-12")  },
                new Student {FirstMidname ="Nethmini", LastName="Nishadi",EnrollmentDate=DateTime.Parse("2016-12-05")  },
            };
            students.ForEach(s => context.Students.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course{CourseID=1050,Title="Chemistry",Credits=3, },
                new Course{CourseID=4022,Title="Microeconomics",Credits=3, },
                new Course{CourseID=4041,Title="Macroeconomics",Credits=3, },
                new Course{CourseID=1045,Title="Calculus",Credits=4, },
                new Course{CourseID=3141,Title="Trigonometry",Credits=4, },
                new Course{CourseID=2021,Title="Composition",Credits=3, },
                new Course{CourseID=2042,Title="Literature",Credits=4, },
            };
            courses.ForEach(s => context.Courses.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment{
                    StudentID =students.Single(s=> s.LastName == "Chamika").ID,
                    CourseID= courses.Single(c=>c.Title=="Cheistry").CourseID,
                    Grade = Grade.A
                },
                new Enrollment{
                    StudentID =students.Single(s=> s.LastName == "Chamika").ID,
                    CourseID= courses.Single(c=>c.Title=="Microeconomics").CourseID,
                    Grade = Grade.C
                },
                new Enrollment{
                    StudentID =students.Single(s=> s.LastName == "Chamika").ID,
                    CourseID= courses.Single(c=>c.Title=="Microeconomics").CourseID,
                    Grade = Grade.B
                },
                new Enrollment{
                    StudentID =students.Single(s=> s.LastName == "Nandathilaka").ID,
                    CourseID= courses.Single(c=>c.Title=="Calculus").CourseID,
                    Grade = Grade.A
                },
                new Enrollment{
                    StudentID =students.Single(s=> s.LastName == "Nandathilaka").ID,
                    CourseID= courses.Single(c=>c.Title=="Trigonometry").CourseID,
                    Grade = Grade.A
                },
                new Enrollment{
                    StudentID =students.Single(s=> s.LastName == "Nandathilaka").ID,
                    CourseID= courses.Single(c=>c.Title=="Composition").CourseID,
                    Grade = Grade.A
                },
                new Enrollment{
                    StudentID =students.Single(s=> s.LastName == "Indrachapa").ID,
                    CourseID= courses.Single(c=>c.Title=="Chemistry").CourseID,
                    Grade = Grade.A
                },
                new Enrollment{
                    StudentID =students.Single(s=> s.LastName == "Thilaka").ID,
                    CourseID= courses.Single(c=>c.Title=="Microeconomics").CourseID,
                    Grade = Grade.A
                },
                new Enrollment{
                    StudentID =students.Single(s=> s.LastName == "Chathuranga").ID,
                    CourseID= courses.Single(c=>c.Title=="Chemistry").CourseID,
                    Grade = Grade.A
                },
                new Enrollment{
                    StudentID =students.Single(s=> s.LastName == "Perera").ID,
                    CourseID= courses.Single(c=>c.Title=="Composition").CourseID,
                    Grade = Grade.A
                },
                new Enrollment{
                    StudentID =students.Single(s=> s.LastName == "Samanthi").ID,
                    CourseID= courses.Single(c=>c.Title=="Literature").CourseID,
                    Grade = Grade.A
                },


            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(

                    s => 
                    s.Student.ID == e.StudentID && 
                    s.Course.CourseID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase==null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}
