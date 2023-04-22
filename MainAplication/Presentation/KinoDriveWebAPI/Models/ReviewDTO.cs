using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDriveWebAPI.Models
{
    public class ReviewDTO
    {
        public int FilmId { get; set; }
        public int Value { get; set; }
        public string? Description { get; set; }
    }
}
