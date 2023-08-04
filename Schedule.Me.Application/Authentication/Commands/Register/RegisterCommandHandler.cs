using ErrorOr;
using MediatR;
using Schedule.Me.Application.Authentication.Common;
using Schedule.Me.Application.Common.Interfaces.Authentication;
using Schedule.Me.Application.Common.Interfaces.Persistence;
using Schedule.Me.Domain.Common.Errors;
using Schedule.Me.Domain.Entities;

namespace Schedule.Me.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler :
        IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }
        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            // 1. Check if user already exists
            if (_userRepository.GetUserByEmail(command.Email) != null)
            {
                return Errors.User.DuplicateEmail;
            }

            // 2. Create user (generate unique id) and persist to database
            var user = new User
            {
                Email = command.Email,
                Password = command.Password,
                FirstName = command.FirstName,
                LastName = command.LastName
            };
            _userRepository.Add(user);
            // 3. Generate JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(
                user,
                token);
        }
    }
}