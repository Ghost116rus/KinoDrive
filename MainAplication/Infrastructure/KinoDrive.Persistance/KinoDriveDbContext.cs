using KinoDrive.Aplication.Interfaces;
using KinoDrive.Domain;
using KinoDrive.Persistance.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;


namespace KinoDrive.Persistance
{
    public class KinoDriveDbContext : DbContext, IKinoDriveDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<BranchOffice> BranchOffices { get; set; }
        public DbSet<Film> Films { get; set; }

        public DbSet<CinemaHall> CinemaHalls { get; set; }
        public DbSet<Seance> Seances { get; set; }
        public DbSet<Booking> Bookings{ get; set; }

        public DbSet<Review> Reviews { get; set; }
        public DbSet<UserFilmRating> UserFilmRatings { get; set; }
        public DbSet<Complaint> Complaints { get; set; }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<FilmDirector> FilmDirectors { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<FilmImage> FilmImages { get; set; }


        public KinoDriveDbContext(DbContextOptions<KinoDriveDbContext> options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BranchOfficeConfiguration());
            builder.ApplyConfiguration(new FilmConfiguration());

            builder.ApplyConfiguration(new CinemaHallComfiguration());
            builder.ApplyConfiguration(new SeanceConfiguration());
            builder.ApplyConfiguration(new BookingConfiguration());

            builder.ApplyConfiguration(new ComplaintsConfiguration());
            builder.ApplyConfiguration(new ReviewConfiguration());        
            builder.ApplyConfiguration(new UserFilmRatingComfiguration());        
            builder.ApplyConfiguration(new FilmImageConfiguration());        

            base.OnModelCreating(builder);
        }
    }
}
