using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Seanses.Commands.CreateNewShedule
{
    public class FilmDTO
    {
        public int Id { get; set; }
        public int Duration { get; set; }
    }
    public class SeanceDTO
    {
        public int Id { get; set; }
        public int cost { get; set; }
        public string Type { get; set; }
        public FilmDTO Film { get; set; }
    }

    public class HallDTO
    {
        public int Id { get; set; }
        public List<SeanceDTO> Seances { get; set; }
    }


    public class DayShedule
    {
        public DateTime Date { get; set; }
        public int BranchOfficeId { get; set; }

        public List<HallDTO> Halls { get; set; }

    }

    public class MakeSheduleCommand : IRequest
    {
        public DayShedule Shedule { get; set; }
        public List<SeanceDTO>? Basket { get; set; }
    }
}
