using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.InfraStructure.Configurations
{
    public class StudentSubjectConfiguration : IEntityTypeConfiguration<StudentSubject>
    {
        public void Configure(EntityTypeBuilder<StudentSubject> Entity)
        {
            Entity.HasKey(ds => new { ds.StudID, ds.SubID });

            Entity.HasOne(x => x.Student)
              .WithMany(x => x.StudentSubjects)
              .HasForeignKey(x => x.StudID);

            Entity.HasOne(x => x.Subject)
            .WithMany(x => x.StudentsSubjects)
            .HasForeignKey(x => x.SubID);
        }
    }
}
