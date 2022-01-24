using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW3.Entity;

namespace Module4HW3.EntityConfig
{
    public class ProjectConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Project").HasKey(p => p.ProjectId);
            builder.Property(p => p.ProjectId).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasMaxLength(50);
            builder.Property(p => p.Budget).HasColumnType("money");
            builder.HasOne(p => p.Client)
                .WithMany(c => c.Projects)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
