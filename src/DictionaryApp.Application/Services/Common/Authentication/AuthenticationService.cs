using DictionaryApp.Application.Abstractions;
using DictionaryApp.Application.Common.Abstractions.Authentication;
using DictionaryApp.Domain.Abstractions;
using DictionaryApp.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace DictionaryApp.Application.Services.Common.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserData _userData;
    private readonly ITokenGenerator _tokenGenerator;

    public AuthenticationService(IUserData userData, ITokenGenerator tokenGenerator)
    {
        _userData = userData;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<AuthenticationResult> Register(
        string userName,
        string firstName,
        string lastName,
        string email,
        string password)
    {
        if (await _userData.GetByUserNameAsync(userName) is not null)
            throw new Exception("UserName already taken");

        var user = new User
        {
            UserName = userName,
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            PasswordHash = Guid.NewGuid().ToString(), // temporary for now
        };

        var newUser = await _userData.CreateAsync(user);
        var token = _tokenGenerator.GenerateUserToken(newUser);
        var cookieOptions = _tokenGenerator.GetUserTokenCookieOptions();

        return new AuthenticationResult(newUser, token, cookieOptions);
    }

    public CookieOptions GetRemoveTokenFromCookieOptions() =>
        _tokenGenerator.GetRemoveTokenFromCookieOptions();

    public CookieOptions GetUserTokenCookieOptions() =>
        _tokenGenerator.GetUserTokenCookieOptions();

    public Task<UserResult> GetUser(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<UserResult> GetUser(string email)
    {
        throw new NotImplementedException();
    }

    public Task<AuthenticationResult> Login(
        string userName,
        string password)
    {
        throw new NotImplementedException();
    }
}
