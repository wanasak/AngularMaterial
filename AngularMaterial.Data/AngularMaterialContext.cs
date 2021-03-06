﻿using AngularMaterial.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularMaterial.Data
{
    public class AngularMaterialContext : DbContext
    {
        public AngularMaterialContext()
            : base("AngularMaterial")
        {
            Database.SetInitializer<AngularMaterialContext>(null);
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = false;
        }

        public IDbSet<Student> StudentSets { get; set; }
        public IDbSet<Course> CourseSets { get; set; }
        public IDbSet<Enrollment> EnrollmentSets { get; set; }
        public IDbSet<Department> DepartmentSets { get; set; }
        public IDbSet<Instructor> InstructorSets { get; set; }
        public IDbSet<CourseInstructor> CourseInstructorSets { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // Configuration Student
            modelBuilder.Entity<Student>()
                .Property(s => s.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Student>()
                .Property(s => s.LastName)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Student>()
                .Property(s => s.Image)
                .IsOptional()
                .HasMaxLength(100);
            modelBuilder.Entity<Student>()
                .Property(s => s.Email)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Student>()
                .HasRequired(s => s.Department)
                .WithMany()
                .WillCascadeOnDelete(false);
                //.HasOptional(s => s.Department)
                //.WithMany()
                //.HasForeignKey(s => s.DepartmentID);
                //.HasOptional(s => s.Department)
                //.WithMany()
                //.HasForeignKey(s => s.DepartmentID)
                //.WillCascadeOnDelete(false);
            // Configuration Course
            modelBuilder.Entity<Course>()
                .Property(c => c.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Course>()
                .Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(100);
            //modelBuilder.Entity<Course>()
            //    .HasMany(c => c.Instructors)
            //    .WithMany(i => i.Courses)
            //    .Map(t => t.MapLeftKey("CourseID")
            //        .MapRightKey("InstructorID")
            //        .ToTable("CourseInstructor"));
            // Configuration Department
            modelBuilder.Entity<Department>()
                .Property(d => d.Code)
                .IsRequired()
                .HasMaxLength(3);
            modelBuilder.Entity<Department>()
                .Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Department>()
                .Property(d => d.Address)
                .IsRequired()
                .HasMaxLength(200);
            modelBuilder.Entity<Department>()
                .Property(d => d.StartDate)
                .IsRequired();
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Students)
                .WithRequired()
                .HasForeignKey(s => s.DepartmentID)
                .WillCascadeOnDelete(false);
            // Configuration Instructor
            modelBuilder.Entity<Instructor>()
                .Property(i => i.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Instructor>()
                .Property(i => i.LastName)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Instructor>()
                .Property(i => i.HireDate)
                .IsRequired();
            // Configuration Enrollment
        }
    }
}
