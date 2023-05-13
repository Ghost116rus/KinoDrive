using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.FilmsStaff.Commands.FilmGenresCRUD.UpdateGenre
{
    public class UpdateGenreCommand : IRequest
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
