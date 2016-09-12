namespace AngularMaterial.Data.Migrations
{
    using AngularMaterial.Entity;
using System;
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
            context.CourseSets.AddOrUpdate(
                c => c.ID,
                new Course { ID = 1050, Title = "Chemistry", Credits = 3, },
                new Course { ID = 4022, Title = "Microeconomics", Credits = 3, },
                new Course { ID = 4041, Title = "Macroeconomics", Credits = 3, },
                new Course { ID = 1045, Title = "Calculus", Credits = 4, },
                new Course { ID = 3141, Title = "Trigonometry", Credits = 4, },
                new Course { ID = 2021, Title = "Composition", Credits = 3, },
                new Course { ID = 2042, Title = "Literature", Credits = 4, }
                );
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
    }
}
