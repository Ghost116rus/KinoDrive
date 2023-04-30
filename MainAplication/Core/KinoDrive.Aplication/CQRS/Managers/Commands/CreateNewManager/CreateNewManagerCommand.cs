using KinoDrive.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Managers.Commands.CreateNewManager
{
    public class CreateNewManagerCommand : IRequest<int>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; } = "Manager";
        public int BranchOfficeId { get; set; }
    }
}
