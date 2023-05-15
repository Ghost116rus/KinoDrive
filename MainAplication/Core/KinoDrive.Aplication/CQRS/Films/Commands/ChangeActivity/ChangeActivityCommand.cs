using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Films.Commands.ChangeActivity
{
    public class ChangeActivityCommand : IRequest
    {
        public int FilmId { get; set; }
        public bool IsActive { get; set; }
    }
}
