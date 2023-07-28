namespace BuberDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
    AuthenticationResult Register(string email, string password, string firstName, string lastName);
    AuthenticationResult Login(string email, string password);
}