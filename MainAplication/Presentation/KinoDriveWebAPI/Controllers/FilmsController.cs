using AutoMapper;
using KinoDrive.Aplication.CQRS.Films.Queries.GetFilmList;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDriveWebAPI.Controllers
{
    public class FilmsController : BaseController
    {
        private readonly IMapper _mapper;

        public FilmsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ActiveFilmListVM>> GetActiveFilms()
        {
            var query = new GetActiveFilmListQuery();

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }



    }
}
