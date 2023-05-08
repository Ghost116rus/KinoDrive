using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.FilmsStaff.Commands.FilmDirectorCRUD.UpdateFilmDirector
{
    public class UpdateFilmDirectorCommand : IRequest
    {
        public int filmDirectorId { get; set; }
        public string Name { get; set; }
    }
}
