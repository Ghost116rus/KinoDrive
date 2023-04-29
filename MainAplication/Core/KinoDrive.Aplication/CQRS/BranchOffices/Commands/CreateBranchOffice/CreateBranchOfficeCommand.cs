using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.BranchOffices.Commands.CreateBranchOffice
{


    public class CreateBranchOfficeCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string Description { get; set; }

        public int StartWorkTime { get; set; }
        public int EndWorkTime { get; set; }

        public string City { get; set; }
        public string Adress { get; set; }



        public float Longitude { get; set; }
        public float Latitude { get; set; }

        public IEnumerable<CinemaHallLookupDTO> CinemaHallsList { get; set; } = new List<CinemaHallLookupDTO>();

    }
}
