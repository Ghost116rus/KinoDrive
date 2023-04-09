using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MediaCore.Domain
{
    [Table("FilmImages")]
    public class FilmImage
    {

        public int FilmId { get; set; }
        public string UrlForFile { get; set; }
        public string FileName { get; set; }
    }
}
