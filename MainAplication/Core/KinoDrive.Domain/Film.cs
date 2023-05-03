
namespace KinoDrive.Domain
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        public int Length { get; set; }

        public bool isActive { get; set; }
        public int AgeRestriction { get; set; }

        public float Rating { get; set; }
        public float? RatingOnKinopoisk { get; set; }
        public float? RatingOnImdb { get; set; }

        public string? UrlForTrailer { get; set; }
        public string? UrlForKinopoisk { get; set; }
        public string? UrlForPoster{ get; set; }

        public IEnumerable<Review>? Reviews { get; set; }
        public IEnumerable<Seance>? Seances { get; set; }

        public IEnumerable<Genre>? Genres { get; set; } 
        public IEnumerable<FilmDirector>? FilmDirectors { get; set; }
        public IEnumerable<Actor>? Actors { get; set; }
        public IEnumerable<FilmImage>? Images { get; set; }
    }
}
