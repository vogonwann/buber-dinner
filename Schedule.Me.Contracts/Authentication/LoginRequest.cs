namespace Schedule.Me.Contracts.Authentication;

public record LoginRequest(
    string Email,
    string Password
);