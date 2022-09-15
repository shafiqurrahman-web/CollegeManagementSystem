using CollegeManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Reflection.Emit;

namespace CollegeManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureCreated();           
            //Database.EnsureDeleted();
        }
        public DbSet<StudentRegistration> StudentRegistration { get; set; }
        public DbSet<AssociateType> AssociateType { get; set; }
       public DbSet<AssociateDesignation> AssociateDesignation { get; set; }
        public DbSet<StudentSubjects> StudentSubjects { get; set; }
        public DbSet<StudentMarks> StudentMarks { get; set; }
        public DbSet<StudentFeed> StudentFeed { get; set; }
        public DbSet<StudentAttendance> StudentAttendance { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<StudentRegistration>().ToTable("StudentRegistration").HasKey("StudentId");
            modelBuilder.Entity<StudentAttendance>().ToTable("StudentAttendance").HasKey("AttendanceId");
            modelBuilder.Entity<AssociateType>().ToTable("AssociateType").HasKey(x => x.TypeId);
            //modelBuilder.Entity<AssociateType>().ToTable("AssociateType").HasKey(x => new { x.TypeId, x.TypeName }); //compositeprimaryKey
            modelBuilder.Entity<AssociateDesignation>().ToTable("AssociateDesignation").HasKey(x => x.DesignationId);
            modelBuilder.Entity<StudentSubjects>().ToTable("StudentSubjects").HasKey(x=>x.SubjectId);
            modelBuilder.Entity<StudentMarks>().ToTable("StudentMarks").HasKey(x => x.MarksId);
            modelBuilder.Entity<StudentFeed>().ToTable("StudentFeed").HasKey(x => x.FeedId);


            modelBuilder.Entity<StudentFeed>()
                .HasOne(s=>s.StudentRegistration)
                .WithMany(c=>c.StudentFeeds)
                .HasForeignKey(s=>s.StudentId)
                .HasPrincipalKey(s=>s.StudentRegistrationId);
        }
    }
}