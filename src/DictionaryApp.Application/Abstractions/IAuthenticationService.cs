using DictionaryApp.Application.Services.Common.Authentication;
using Microsoft.AspNetCore.Http;

namespace DictionaryApp.Application.Abstractions;

public interface IAuthenticationService
{
    Task<AuthenticationResult> Register(
        string userName,
        string firstName,
        string lastName,
        string email,
        string password);

    Task<AuthenticationResult> Login(
        string userName,
        string password);

    Task<UserResult> GetUser(Guid id);

    Task<UserResult> GetUser(string email);

    CookieOptions GetRemoveTokenFromCookieOptions();

    CookieOptions GetUserTokenCookieOptions();
}