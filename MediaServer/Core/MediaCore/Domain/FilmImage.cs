using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MediaCore.Domain
{
    [Table("FilmImages")]
    public class FilmImage
    {
        public int Id { get; set; }

        public string UrlForFile { get; set; }
        public string FileName { get; set; }

        public int FilmId { get; set; }
        public Film Film { get; set; }
    }
}
