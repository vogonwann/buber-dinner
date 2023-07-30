using BuberDinner.Application.Services.Authentication.Common;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication;

public interface IAuthenticationCommandService
{
    ErrorOr<AuthenticationResult> Register(string email, string password, string firstName, string lastName);
}