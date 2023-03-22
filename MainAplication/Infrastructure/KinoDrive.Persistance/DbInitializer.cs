using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Persistance
{
    public static class DbInitializer
    {
        public static void Initialize(KinoDriveDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
