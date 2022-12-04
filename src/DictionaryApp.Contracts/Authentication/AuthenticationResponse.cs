namespace DictionaryApp.Contracts.Authentication;

public record AuthenticationResponse(
    Guid Id,
    string UserName,
    string FirstName,
    string LastName,
    string Email,
    string Token
);
