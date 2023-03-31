using AutoMapper;
using KinoDrive.Aplication.CQRS.BranchOffices.Commands.CreateBranchOffice;
using KinoDrive.Aplication.CQRS.BranchOffices.Queries;
using KinoDrive.Aplication.CQRS.BranchOffices.Queries.GetBranchDetails;
using KinoDrive.Aplication.CQRS.BranchOffices.Queries.GetBranchOfficesListByCity;
using KinoDriveWebAPI.Models;
using Microsoft.AspNetCore.Mvc;


namespace KinoDriveWebAPI.Controllers
{
    public class BranchOfficesController : BaseController
    {
        private readonly IMapper mapper;

        public BranchOfficesController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateBranchOfficeDTO createDTO)
        {
            var command = mapper.Map<CreateBranchOfficeCommand>(createDTO);
            var newBranchId = await Mediator.Send(command);

            return Created(newBranchId.ToString(), newBranchId);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BranchOfficeVm>> GetDetailInfoAboutBranch(int id)
        {
            var query = new GetBranchOfficeDetailsQuery
            {
                Id = id
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{city}")]
        public async Task<ActionResult<BranchOfficeListVm>> GetOfficesListByCity(string city)
        {
            var query = new GetBranchOfficesListByCityQuery { City = city };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

    }
}
