using AutoMapper;
using KinoDrive.Aplication.CQRS.Films.Queries.GetFilmDetail;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.BranchOffices.Queries.GetBranchOfficeShedule
{

    //public class GetBranchOfficeSheduleQueryHandler :
    //    IRequestHandler<GetBranchOfficeSheduleQuery, BranchOfficeSheduleVm>
    //{
    //    private readonly IMapper mapper;
    //    private readonly IKinoDriveDbContext kinoDriveDbContext;

    //    public GetBranchOfficeSheduleQueryHandler(IMapper mapper, IKinoDriveDbContext kinoDriveDbContext)
    //    {
    //        this.mapper = mapper;
    //        this.kinoDriveDbContext = kinoDriveDbContext;
    //    }

    //    public async Task<BranchOfficeSheduleVm> Handle(GetBranchOfficeSheduleQuery request,
    //        CancellationToken cancellationToken)
    //    {

    //    }
    //}
}
