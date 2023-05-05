using KinoDrive.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Managers.Commands.UpdateManager
{
    public class UpdateManagerCommand : IRequest
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string NickName { get; set; }
        public int BranchOfficeId { get; set; }
    }
}
