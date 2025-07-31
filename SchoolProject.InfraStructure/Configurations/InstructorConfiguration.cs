using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.InfraStructure.Configurations
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> Entity)
        {
            Entity.HasOne(s => s.Supervisor)
                  .WithMany(s => s.Instructors)
                  .HasForeignKey(s => s.SubervisorId)
                  .OnDelete(DeleteBehavior.Restrict);

            Entity.HasKey(i => i.InsId);
            Entity.Property(X => X.Address).HasMaxLength(200);
            Entity.HasOne(i => i.Supervisor)
           .WithMany(x => x.Instructors)
           .HasForeignKey(i => i.SubervisorId)
           .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
