using KinoDrive.Aplication.Interfaces;
using KinoDrive.Domain;
using KinoDrive.Persistance.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;


namespace KinoDrive.Persistance
{
    public class KinoDriveDbContext : DbContext, IKinoDriveDbContext
    {
        public DbSet<BranchOffice> BranchOffices { get; set; }
        public DbSet<CinemaHall> CinemaHalls{ get; set; }

        public KinoDriveDbContext(DbContextOptions<KinoDriveDbContext> options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BranchOfficeConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
