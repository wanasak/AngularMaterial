using AngularMaterial.Entity;
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
        }

        public IDbSet<Student> StudentSets { get; set; }
        public IDbSet<Course> CourseSets { get; set; }
        public IDbSet<Enrollment> EnrollmentSets { get; set; }

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
            // Configuration Course
            modelBuilder.Entity<Course>()
                .Property(c => c.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Course>()
                .Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(100);
            // Configuration Enrollment
        }
    }
}
