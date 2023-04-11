using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.Common.Exceptions
{
    public class BadDataException : Exception
    {
        public BadDataException(string name)
            : base($"Entered data not correct  \"{name}\"") { }
    }
}
