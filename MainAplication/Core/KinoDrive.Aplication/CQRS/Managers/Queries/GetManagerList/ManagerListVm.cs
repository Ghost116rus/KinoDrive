﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Managers.Queries.GetManagerList
{
    public class ManagerListVm
    {
        public IList<ManagerVm> ManagerList { get; set; }
    }
}
