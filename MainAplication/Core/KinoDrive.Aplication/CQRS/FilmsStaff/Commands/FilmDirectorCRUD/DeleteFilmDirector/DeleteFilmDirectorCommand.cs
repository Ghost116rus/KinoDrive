using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.FilmsStaff.Commands.FilmDirectorCRUD.DeleteFilmDirector
{
    public class DeleteFilmDirectorCommand : IRequest
    {
        public int Id { get; set; }
    }
}
