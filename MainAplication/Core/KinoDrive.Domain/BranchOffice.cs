using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Domain
{
    public class BranchOffice
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }
    }
}
