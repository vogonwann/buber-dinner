using BuberDinner.Application.Services.Authentication.Common;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
            string Email,
            string Password,
            string FirstName,
            string LastName) : IRequest<ErrorOr<AuthenticationResult>>;
}