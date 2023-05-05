using KinoDrive.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace KinoDrive.Persistance.EntityTypeConfiguration
{
    public class BranchOfficeConfiguration : IEntityTypeConfiguration<BranchOffice>
    {
        public void Configure(EntityTypeBuilder<BranchOffice> builder)
        {
            builder.HasKey(branch => branch.Id);
            builder.HasIndex(branch => branch.Id).IsUnique();
            builder.Property(branch => branch.City).HasMaxLength(50);
            builder.Property(branch => branch.Name).HasMaxLength(155);
            builder.Property(branch => branch.Adress).HasMaxLength(255);
            builder.Property(branch => branch.Description).HasMaxLength(1000);
            builder.Property(branch => branch.MobilePhone).HasColumnType("char(11)");
            builder.Property(branch => branch.Email).HasMaxLength(255);

        }
    }
}
