using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Register(
        string email, 
        string password, 
        string firstName, 
        string lastName)
    {
        // Check if user already exists

        // Create user (generate unique id)

        // Generate JWT token
        var token = _jwtTokenGenerator.GenerateToken(Guid.NewGuid(), firstName, lastName);
        return new AuthenticationResult(Guid.NewGuid(), email, token, firstName, lastName);
    }
    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(), 
            email, 
            "token", 
            "firstName", 
            "lastName");
    }
}