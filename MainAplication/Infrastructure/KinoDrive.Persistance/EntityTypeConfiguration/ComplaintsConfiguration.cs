using KinoDrive.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KinoDrive.Persistance.EntityTypeConfiguration
{
    public class ComplaintsConfiguration : IEntityTypeConfiguration<Complaint>
    {
        public void Configure(EntityTypeBuilder<Complaint> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id);

            builder
                .HasOne(office => office.BranchOffice)
                .WithMany(c => c.Complaintes)
                .HasForeignKey(f => f.BranchOfficeId);

            builder
                .HasOne(user => user.User)
                .WithMany(c => c.Complaintes)
                .HasForeignKey(f => f.UserId);

            builder.Property(c => c.Description).HasMaxLength(2000);
        }
    }
}
