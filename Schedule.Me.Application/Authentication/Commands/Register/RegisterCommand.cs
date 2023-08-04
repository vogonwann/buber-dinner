using ErrorOr;
using MediatR;
using Schedule.Me.Application.Authentication.Common;

namespace Schedule.Me.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
            string Email,
            string Password,
            string FirstName,
            string LastName) : IRequest<ErrorOr<AuthenticationResult>>;
}