using Schedule.Me.Domain.Entities;

namespace Schedule.Me.Application.Authentication.Common
{
    public record AuthenticationResult(User User, string Token);
}