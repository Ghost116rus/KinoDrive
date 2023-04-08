using KinoDrive.Domain;

namespace KinoDrive.Aplication.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
