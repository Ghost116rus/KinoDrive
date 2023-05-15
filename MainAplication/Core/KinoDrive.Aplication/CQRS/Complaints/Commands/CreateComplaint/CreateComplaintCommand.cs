using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Complaints.Commands.CreateComplaint
{
    public class CreateComplaintCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public string Description { get; set; }
        public int? BranchOfficeId { get; set; }
    }
}
