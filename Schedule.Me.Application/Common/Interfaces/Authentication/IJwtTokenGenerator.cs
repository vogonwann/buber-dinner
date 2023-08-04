using Schedule.Me.Domain.Entities;

namespace Schedule.Me.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}