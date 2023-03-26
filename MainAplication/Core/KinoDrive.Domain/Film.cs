
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

        public float Rating { get; set; }
        public float RatingOnKinopoisk { get; set; }
        public int RatingOnImdb { get; set; }

        public IEnumerable<Review> Reviews { get; set; } = new List<Review>();
        public IEnumerable<Seance> Seances { get; set; } = new List<Seance>();

        public IEnumerable<Genre> Genres { get; set; } = new List<Genre>();
        public IEnumerable<FilmDirector> FilmDirectors { get; set; } = new List<FilmDirector>();
        public IEnumerable<Actor> Films { get; set; } = new List<Actor>();
    }
}
