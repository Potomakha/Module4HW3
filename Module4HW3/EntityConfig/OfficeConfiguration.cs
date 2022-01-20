using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW3.Entity;

namespace Module4HW3.EntityConfig
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.ToTable("Office").HasKey(o => o.OfficeId);
            builder.Property(o => o.OfficeId).ValueGeneratedOnAdd();
            builder.Property(o => o.Title).HasMaxLength(100);
            builder.Property(o => o.Location).HasMaxLength(100);
        }
    }
}
