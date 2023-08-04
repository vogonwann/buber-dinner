using ErrorOr;
using MediatR;
using Schedule.Me.Application.Authentication.Common;

namespace Schedule.Me.Application.Authentication.Queries.Login
{
    public record LoginQuery(
            string Email,
            string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}