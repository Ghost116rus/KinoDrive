using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Domain
{
    public class FilmImage
    {
        public int Id { get; set; }

        public string UrlForFile { get; set; }
        public string FileName { get; set; }

        public int FilmId { get; set; }
        public Film Film { get; set; }
    }
}
