using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.InfraStructure.Configurations
{
    public class Ins_SubjectConfiguration : IEntityTypeConfiguration<Ins_Subject>
    {
        public void Configure(EntityTypeBuilder<Ins_Subject> Entity)
        {
            Entity.HasKey(ds => new { ds.InsId, ds.SubId });

            Entity.HasOne(x => x.instructor)
              .WithMany(x => x.Ins_Subjects)
              .HasForeignKey(x => x.InsId);

            Entity.HasOne(x => x.Subject)
            .WithMany(x => x.Ins_Subjects)
            .HasForeignKey(x => x.SubId);
        }
    }
}
