namespace AngularMaterial.Data.Migrations
{
    using AngularMaterial.Entity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AngularMaterial.Data.AngularMaterialContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AngularMaterial.Data.AngularMaterialContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.StudentSets.AddOrUpdate(
                s => s.FirstName,
                new Student { FirstName = "Andrew", LastName = "Peters", Image = "ic_face_black_48px.svg", Email = "abc@gmail.com" },
                new Student { FirstName = "Brice", LastName = "Lambson", Image = "ic_face_black_48px.svg", Email = "brice1234@yahoo.com" },
                new Student { FirstName = "Rowan", LastName = "Miller", Image = "ic_face_black_48px.svg", Email = "rm_24@hotmail.com" },
                new Student { FirstName = "Peggy", LastName = "Justice", Image = "ic_face_black_48px.svg", Email = "xyz@gmail.com" },
                new Student { FirstName = "Alan", LastName = "Smith", Image = "ic_face_black_48px.svg", Email = "qwerty@gmail.com" },
                new Student { FirstName = "Yan", LastName = "Li", Image = "ic_face_black_48px.svg", Email = "yan_li@facebook.com" },
                new Student { FirstName = "Nino", LastName = "Olivetto", Image = "ic_face_black_48px.svg", Email = "nino2008@gmail.com" }
                );
            context.SaveChanges();
            context.DepartmentSets.AddOrUpdate(
                d => d.Name,
                new Department { Name = "Human", StartDate = new DateTime(1999, 10, 1), Address = "56 Navigation St, Birmingham B2 4BT, UK" },
                new Department { Name = "Education", StartDate = new DateTime(1990, 4, 30), Address = "17 Victoria Rd, Salford M6 8FZ, UK" },
                new Department { Name = "Fineart", StartDate = new DateTime(1987, 11, 28), Address = "176 Oxford Rd, Manchester M13 9QQ, UK" },
                new Department { Name = "Science", StartDate = new DateTime(1979, 3, 4), Address = "2-3 Brunswick Pl, Southampton SO15 2AN, UK" },
                new Department { Name = "Engineering", StartDate = new DateTime(1955, 1, 21), Address = "Laurel Rd, Ferryhill DL17 0DW, UK" },
                new Department { Name = "Medicine", StartDate = new DateTime(2009, 6, 11), Address = "19 Robert Burns Ct, Beith KA15 1DN, UK" },
                new Department { Name = "Nurse", StartDate = new DateTime(2009, 6, 11), Address = "19 Robert Burns Ct, Beith KA15 1DN, UK" },
                new Department { Name = "Economic", StartDate = new DateTime(2009, 6, 11), Address = "19 Robert Burns Ct, Beith KA15 1DN, UK" },
                new Department { Name = "Camt", StartDate = new DateTime(2009, 6, 11), Address = "19 Robert Burns Ct, Beith KA15 1DN, UK" },
                new Department { Name = "Dentist", StartDate = new DateTime(2009, 6, 11), Address = "19 Robert Burns Ct, Beith KA15 1DN, UK" },
                new Department { Name = "Law", StartDate = new DateTime(2009, 6, 11), Address = "19 Robert Burns Ct, Beith KA15 1DN, UK" },
                new Department { Name = "Pharmacy", StartDate = new DateTime(2009, 6, 11), Address = "19 Robert Burns Ct, Beith KA15 1DN, UK" }
                );
            context.SaveChanges();
            context.InstructorSets.AddOrUpdate(
                i => i.FirstName,
                new Instructor { FirstName = "Kim", LastName = "Abercrombie", HireDate = new DateTime(1999, 12, 23)},
                new Instructor { FirstName = "Fadi", LastName = "Roger", HireDate = new DateTime(2005, 2, 11)},
                new Instructor { FirstName = "Harui", LastName = "Kapoor", HireDate = new DateTime(1979, 1, 5)},
                new Instructor { FirstName = "Zheng", LastName = "Hatori", HireDate = new DateTime(2011, 7, 3)},
                new Instructor { FirstName = "Joe", LastName = "Yung", HireDate = new DateTime(2002, 8, 18)});
            context.SaveChanges();
            context.CourseSets.AddOrUpdate(
                c => c.ID,
                new Course { ID = 1050, Title = "Chemistry", Credits = 3, DepartmentID = 1, Instructors = new List<Instructor>() },
                new Course { ID = 4022, Title = "Microeconomics", Credits = 3, DepartmentID = 2, Instructors = new List<Instructor>() },
                new Course { ID = 4041, Title = "Macroeconomics", Credits = 3, DepartmentID = 3, Instructors = new List<Instructor>() },
                new Course { ID = 1045, Title = "Calculus", Credits = 4, DepartmentID = 4, Instructors = new List<Instructor>() },
                new Course { ID = 3141, Title = "Trigonometry", Credits = 4, DepartmentID = 5, Instructors = new List<Instructor>() },
                new Course { ID = 2021, Title = "Composition", Credits = 3, DepartmentID = 5, Instructors = new List<Instructor>() },
                new Course { ID = 2042, Title = "Literature", Credits = 4, DepartmentID = 6, Instructors = new List<Instructor>() }
                );
            context.SaveChanges();
            AddOrUpdateInstructor(context, "Chemistry", "Abercrombie");
            AddOrUpdateInstructor(context, "Chemistry", "Kapoor");
            AddOrUpdateInstructor(context, "Calculus", "Hatori");
            AddOrUpdateInstructor(context, "Trigonometry", "Yung");
            AddOrUpdateInstructor(context, "Literature", "Roger");
            context.SaveChanges();
            context.EnrollmentSets.AddOrUpdate(
                new Enrollment { StudentID = 1, CourseID = 1050, Grade = Grade.A },
                new Enrollment { StudentID = 1, CourseID = 4022, Grade = Grade.C },
                new Enrollment { StudentID = 1, CourseID = 4041, Grade = Grade.B },
                new Enrollment { StudentID = 2, CourseID = 1045, Grade = Grade.B },
                new Enrollment { StudentID = 2, CourseID = 3141, Grade = Grade.F },
                new Enrollment { StudentID = 2, CourseID = 2021, Grade = Grade.F },
                new Enrollment { StudentID = 3, CourseID = 1050 },
                new Enrollment { StudentID = 4, CourseID = 1050, },
                new Enrollment { StudentID = 4, CourseID = 4022, Grade = Grade.F },
                new Enrollment { StudentID = 5, CourseID = 4041, Grade = Grade.C },
                new Enrollment { StudentID = 6, CourseID = 1045 },
                new Enrollment { StudentID = 7, CourseID = 3141, Grade = Grade.A }
                );
            context.SaveChanges();
        }

        private void AddOrUpdateInstructor(AngularMaterialContext context, string courseTitle, string instructorName)
        {
            var course = context.CourseSets.SingleOrDefault(c => c.Title == courseTitle);
            var instructor = context.InstructorSets.SingleOrDefault(i => i.LastName == instructorName);
            if (instructor != null)
                course.Instructors.Add(instructor);
        }
    }
}
