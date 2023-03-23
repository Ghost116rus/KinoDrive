using KinoDrive.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace KinoDrive.Persistance.EntityTypeConfiguration
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(k => new { k.UserId, k.FilmId });

            builder
                .HasOne(f => f.Film)
                .WithMany(r => r.Reviews)
                .HasForeignKey(f => f.FilmId);
            
            builder
                .HasOne(u => u.User)
                .WithMany(r => r.Reviews)
                .HasForeignKey(f => f.UserId);

            builder.Property(r => r.Description).HasMaxLength(2000);

        }
    }
}
