using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using System.Reflection;

namespace SchoolProject.InfraStructure.Data
{
    public class ApplicationDBContext : DbContext

    {


        public ApplicationDBContext()
        {

        }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<DepartmetSubject> DepartmentSubjects { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

        public DbSet<Ins_Subject> Ins_Subjects { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());











            //go to Configguaripn
            //modelBuilder.Entity<DepartmetSubject>()
            //    .HasKey(ds => new { ds.DID, ds.SubID });
            //modelBuilder.Entity<Ins_Subject>()
            //    .HasKey(ds => new { ds.InsId, ds.SubId });

            //modelBuilder.Entity<StudentSubject>()
            //    .HasKey(ds => new { ds.StudID, ds.SubID });

            //modelBuilder.Entity<Instructor>(Entity =>
            //{
            //    Entity.HasKey(i => i.InsId);
            //    Entity.Property(X => X.Address).HasMaxLength(200);
            //    Entity.HasOne(i => i.Supervisor)
            //   .WithMany(x => x.Instructors)
            //   .HasForeignKey(i => i.SubervisorId)
            //   .OnDelete(DeleteBehavior.Restrict);

            //});



            //modelBuilder.Entity<DepartmetSubject>(Entity =>
            //{
            //    Entity.HasOne(x => x.Department)
            //    .WithMany(x => x.DepartmentSubjects)
            //    .HasForeignKey(x => x.DID);

            //    Entity.HasOne(x => x.Subjects)
            //    .WithMany(x => x.DepartmetsSubjects)
            //    .HasForeignKey(x => x.SubID);
            //});

            //modelBuilder.Entity<Ins_Subject>(Entity =>
            //{
            //    Entity.HasOne(x => x.instructor)
            //    .WithMany(x => x.Ins_Subjects)
            //    .HasForeignKey(x => x.InsId);

            //    Entity.HasOne(x => x.Subject)
            //    .WithMany(x => x.Ins_Subjects)
            //    .HasForeignKey(x => x.SubId);
            //});

            //modelBuilder.Entity<StudentSubject>(Entity =>
            //{
            //    Entity.HasOne(x => x.Student)
            //    .WithMany(x => x.StudentSubjects)
            //    .HasForeignKey(x => x.StudID);

            //    Entity.HasOne(x => x.Subject)
            //    .WithMany(x => x.StudentsSubjects)
            //    .HasForeignKey(x => x.SubID);
            //});



            //modelBuilder.Entity<Instructor>(Entity =>
            //{

            //    Entity.HasOne(s => s.Supervisor)
            //      .WithMany(s => s.Instructors)
            //      .HasForeignKey(s => s.SubervisorId)
            //      .OnDelete(DeleteBehavior.Restrict);

            //});

            base.OnModelCreating(modelBuilder);




        }
    }
}