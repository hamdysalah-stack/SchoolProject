using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.InfraStructure.Configurations
{
    public class DepartmetSubjectConfiguration : IEntityTypeConfiguration<DepartmetSubject>
    {
        public void Configure(EntityTypeBuilder<DepartmetSubject> Entity)
        {
            Entity.HasKey(ds => new { ds.DID, ds.SubID });

            Entity.HasOne(x => x.Department)
        .WithMany(x => x.DepartmentSubjects)
        .HasForeignKey(x => x.DID);

            Entity.HasOne(x => x.Subjects)
            .WithMany(x => x.DepartmetsSubjects)
            .HasForeignKey(x => x.SubID);
        }
    }
}