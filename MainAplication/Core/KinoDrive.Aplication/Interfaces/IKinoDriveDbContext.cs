using KinoDrive.Domain;
using Microsoft.EntityFrameworkCore;


namespace KinoDrive.Aplication.Interfaces
{
    public interface IKinoDriveDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<BranchOffice> BranchOffices { get; set; }
        public DbSet<Film> Films { get; set; }

        public DbSet<CinemaHall> CinemaHalls { get; set; }
        public DbSet<Seance> Seances { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Review> Reviews { get; set; }
        public DbSet<UserFilmRating> UserFilmRatings { get; set; }
        public DbSet<Complaint> Complaints { get; set; }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<FilmDirector> FilmDirectors { get; set; }
        public DbSet<Actor> Actors { get; set; }

        public DbSet<FilmImage> FilmImages { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
