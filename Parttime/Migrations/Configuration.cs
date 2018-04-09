namespace Parttime.Migrations
{
    using Parttime.DAL;
    using Parttime.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UniversityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //ContextKey = "Parttime.DAL.UniversityContext";
        }

        protected override void Seed(UniversityContext context)
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

            var instructors = new List<Instructor>
            {
                new Instructor{FirstMidname="Saman", LastName="Perera",HireDate=DateTime.Parse("1995-03-11")},
                new Instructor{FirstMidname="Gihan", LastName="Wickramanayake",HireDate=DateTime.Parse("1996-04-08")},
                new Instructor{FirstMidname="Dammika", LastName="Chathuranga",HireDate=DateTime.Parse("1993-12-10")},
                new Instructor{FirstMidname="Madhawa", LastName="Rohan",HireDate=DateTime.Parse("1998-08-22")},
                new Instructor{FirstMidname="Pubudu", LastName="Namal",HireDate=DateTime.Parse("2000-02-23")}
            };
            instructors.ForEach(s => context.Instructors.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            

            var departments = new List<Department>
            {
                new Department{ Name ="English", Budget=350000, StartDate=DateTime.Parse("2007-09-01"),InstructorID = instructors.Single(i => i.LastName=="Perera").ID },
                new Department{ Name ="Mathematics", Budget=100000, StartDate=DateTime.Parse("2007-09-01"),InstructorID = instructors.Single(i => i.LastName=="Wickramanayake").ID },
                new Department{ Name ="Engineering", Budget=35000, StartDate=DateTime.Parse("2007-09-01"),InstructorID = instructors.Single(i => i.LastName=="Chathuranga").ID },
                new Department{ Name ="Economics", Budget=100000, StartDate=DateTime.Parse("2007-09-01"),InstructorID = instructors.Single(i => i.LastName=="Rohan").ID }
            };
            departments.ForEach(s => context.Departments.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course{CourseID=1050,Title="Chemistry",Credits=3,DepartmentID=departments.Single(s => s.Name=="Engineering").DepartmentID,Instructors = new List<Instructor>() },
                new Course{CourseID=4022,Title="Microeconomics",Credits=3,DepartmentID=departments.Single(s => s.Name=="Economics").DepartmentID,Instructors = new List<Instructor>() },
                new Course{CourseID=4041,Title="Macroeconomics",Credits=3,DepartmentID=departments.Single(s => s.Name=="Economics").DepartmentID,Instructors = new List<Instructor>() },
                new Course{CourseID=1045,Title="Calculus",Credits=4,DepartmentID=departments.Single(s => s.Name=="Mathematics").DepartmentID,Instructors = new List<Instructor>() },
                new Course{CourseID=3141,Title="Trigonometry",Credits=4, DepartmentID=departments.Single(s => s.Name=="Engineering").DepartmentID,Instructors = new List<Instructor>()},
                new Course{CourseID=2021,Title="Composition",Credits=3,DepartmentID=departments.Single(s => s.Name=="English").DepartmentID,Instructors = new List<Instructor>() },
                new Course{CourseID=2042,Title="Literature",Credits=4, DepartmentID=departments.Single(s => s.Name=="English").DepartmentID,Instructors = new List<Instructor>()},
            };
            courses.ForEach(s => context.Courses.AddOrUpdate(p => p.CourseID, s));
            context.SaveChanges();

            var officeAssignments = new List<OfficeAssingment>
            {
                new OfficeAssingment{ InstructorID=instructors.Single(i => i.LastName=="Perera").ID, Location="Smith 17" },
                new OfficeAssingment{ InstructorID=instructors.Single(i => i.LastName=="Wickramanayake").ID, Location="Govan 27" },
                new OfficeAssingment{ InstructorID=instructors.Single(i => i.LastName=="Chathuranga").ID, Location="Thompson 304" }
            };
            officeAssignments.ForEach(s => context.OfficeAssingments.AddOrUpdate(p => p.InstructorID, s));
            context.SaveChanges();

            AddOrUpdateInstructor(context, "Chemistry", "Rohan");
            AddOrUpdateInstructor(context, "Chemistry", "Chathuranga");
            AddOrUpdateInstructor(context, "Microeconomics", "Namal");
            AddOrUpdateInstructor(context, "Macroeconomics", "Namal");

            AddOrUpdateInstructor(context, "Calculus", "Wickramanayake");
            AddOrUpdateInstructor(context, "Trigonometry", "Chathuranga");
            AddOrUpdateInstructor(context, "Composition", "Perera");
            AddOrUpdateInstructor(context, "Literature", "Perera");

            context.SaveChanges();


            var enrollments = new List<Enrollment>
            {
                new Enrollment{
                    StudentID =students.Single(s=> s.LastName == "Chamika").ID,
                    CourseID= courses.Single(c=> c.Title=="Cheistry").CourseID,
                    Grade = Grade.A
                },
                new Enrollment{
                    StudentID =students.Single(s=> s.LastName == "Chamika").ID,
                    CourseID= courses.Single(c=> c.Title=="Microeconomics").CourseID,
                    Grade = Grade.C
                },
                new Enrollment{
                    StudentID =students.Single(s=> s.LastName == "Chamika").ID,
                    CourseID= courses.Single(c=> c.Title=="Microeconomics").CourseID,
                    Grade = Grade.B
                },
                new Enrollment{
                    StudentID =students.Single(s=> s.LastName == "Nandathilaka").ID,
                    CourseID= courses.Single(c=> c.Title=="Calculus").CourseID,
                    Grade = Grade.A
                },
                new Enrollment{
                    StudentID =students.Single(s=> s.LastName == "Nandathilaka").ID,
                    CourseID= courses.Single(c=> c.Title=="Trigonometry").CourseID,
                    Grade = Grade.A
                },
                new Enrollment{
                    StudentID =students.Single(s=> s.LastName == "Nandathilaka").ID,
                    CourseID= courses.Single(c=> c.Title=="Composition").CourseID,
                    Grade = Grade.A
                },
                new Enrollment{
                    StudentID =students.Single(s=> s.LastName == "Indrachapa").ID,
                    CourseID= courses.Single(c=> c.Title=="Chemistry").CourseID,
                    Grade = Grade.A
                },
                new Enrollment{
                    StudentID =students.Single(s=> s.LastName == "Thilaka").ID,
                    CourseID= courses.Single(c=> c.Title=="Microeconomics").CourseID,
                    Grade = Grade.A
                },
                new Enrollment{
                    StudentID =students.Single(s=> s.LastName == "Chathuranga").ID,
                    CourseID= courses.Single(c=> c.Title=="Chemistry").CourseID,
                    Grade = Grade.A
                },
                new Enrollment{
                    StudentID =students.Single(s=> s.LastName == "Perera").ID,
                    CourseID= courses.Single(c=> c.Title=="Composition").CourseID,
                    Grade = Grade.A
                },
                new Enrollment{
                    StudentID =students.Single(s=> s.LastName == "Samanthi").ID,
                    CourseID= courses.Single(c=> c.Title=="Literature").CourseID,
                    Grade = Grade.A
                }


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

        private void AddOrUpdateInstructor(UniversityContext context, string courseTitle, string instructorName)
        {
            var crs = context.Courses.SingleOrDefault(c => c.Title == courseTitle);
            var inst = crs.Instructors.SingleOrDefault(i => i.LastName == instructorName);
            if (inst == null)
                crs.Instructors.Add(context.Instructors.Single(i => i.LastName == instructorName));
        }
    }
}
