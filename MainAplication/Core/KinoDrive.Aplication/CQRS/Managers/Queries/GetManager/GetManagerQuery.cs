using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Managers.Queries.GetManager
{
    public class GetManagerQuery :IRequest<ManagerVm>
    {
        public int Id { get; set; }

    }
}
