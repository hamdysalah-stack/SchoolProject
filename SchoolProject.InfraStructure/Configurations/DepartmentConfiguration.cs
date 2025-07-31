using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.InfraStructure.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> Entity)
        {

            {
                Entity.HasKey(d => d.DID);
                Entity.Property(d => d.DName).HasMaxLength(100);


                Entity.HasMany(x => x.Students)
                 .WithOne(x => x.Department)
                    .HasForeignKey(x => x.DID)
                    .OnDelete(DeleteBehavior.Restrict);

                Entity.HasOne(d => d.Supervisor)
               .WithOne(x => x.DepartmentManager)
               .HasForeignKey<Department>(d => d.InsManager)
               .OnDelete(DeleteBehavior.Restrict);

            }
        }
    }
}
