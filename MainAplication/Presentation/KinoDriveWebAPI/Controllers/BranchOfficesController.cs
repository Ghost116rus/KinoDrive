using AutoMapper;
using KinoDrive.Aplication.CQRS.BranchOffices.Commands.CreateBranchOffice;
using KinoDrive.Aplication.CQRS.BranchOffices.Commands.UpdateBranchOffice;
using KinoDrive.Aplication.CQRS.BranchOffices.Queries;
using KinoDrive.Aplication.CQRS.BranchOffices.Queries.GetBranchDetails;
using KinoDrive.Aplication.CQRS.BranchOffices.Queries.GetBranchOfficeDetailInfoForAdmin;
using KinoDrive.Aplication.CQRS.BranchOffices.Queries.GetBranchOfficeShedule;
using KinoDrive.Aplication.CQRS.BranchOffices.Queries.GetBranchOfficesList;
using KinoDrive.Aplication.CQRS.BranchOffices.Queries.GetBranchOfficesListByCity;
using KinoDriveWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateBranchOfficeCommand command)
        {

            var newBranchId = await Mediator.Send(command);

            return Created(newBranchId.ToString(), newBranchId);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}")]
        public async Task<ActionResult<BranchOfficeVm>> GetDetailInfoAboutBranchForAdmin(int id)
        {
            var query = new GetBranchOfficeDetailInfoForAdminQuery
            {
                BranchOfficeId = id
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut]
        public async Task<ActionResult> UpdateBranchOffice([FromBody] UpdateBranchOfficeCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
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



        [HttpGet("{id}")]
        public async Task<ActionResult<BranchOfficeVm>> GetBranchOfficeShedule(int id)
        {
            var query = new GetBranchOfficeSheduleQuery
            {
                BranchOfficeId = id
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet]
        public async Task<ActionResult<BranchOfficeListVm>> GetOfficesList()
        {
            var query = new GetBranchOfficesListQuery();

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
