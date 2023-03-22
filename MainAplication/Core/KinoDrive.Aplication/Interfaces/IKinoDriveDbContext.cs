using KinoDrive.Domain;
using Microsoft.EntityFrameworkCore;


namespace KinoDrive.Aplication.Interfaces
{
    public interface IKinoDriveDbContext
    {
        DbSet<BranchOffice> BranchOffices { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
