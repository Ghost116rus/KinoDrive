using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.Common.Exceptions
{
    public class RegisterException : Exception
    {
        public RegisterException()
            : base("Такой пользователь уже существует") { }
    }
}
