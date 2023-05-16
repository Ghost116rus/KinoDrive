using KinoDrive.Aplication.CQRS.Complaints.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Complaints.Queries.GetAllComplaints
{
    public class GetAllComplaintsQuery : IRequest<List<ComplaintVM>>
    {

    }
}
