using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationCommandService : IAuthenticationCommandService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Register(
        string email,
        string password,
        string firstName,
        string lastName)
    {
        // 1. Check if user already exists
        if (_userRepository.GetUserByEmail(email) != null)
        {
            return Errors.User.DuplicateEmail;
        }

        // 2. Create user (generate unique id) and persist to database
        var user = new User
        {
            Email = email,
            Password = password,
            FirstName = firstName,
            LastName = lastName
        };
        _userRepository.Add(user);
        // 3. Generate JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
            user,
            token);
    }
    
}