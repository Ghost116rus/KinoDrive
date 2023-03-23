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

        public DbSet<Film> Films { get; set; }

        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<User> Users { get; set; }

        public KinoDriveDbContext(DbContextOptions<KinoDriveDbContext> options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BranchOfficeConfiguration());
            builder.ApplyConfiguration(new CinemaHallComfiguration());
            builder.ApplyConfiguration(new ComplaintsConfiguration());
            builder.ApplyConfiguration(new FilmConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
