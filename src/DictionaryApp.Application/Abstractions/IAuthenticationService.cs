using DictionaryApp.Application.Services.Common.Authentication;
using Microsoft.AspNetCore.Http;

namespace DictionaryApp.Application.Abstractions;

public interface IAuthenticationService
{
    Task<AuthenticationResult> RegisterAsync(
        string userName,
        string firstName,
        string lastName,
        string email,
        string password);

    Task<AuthenticationResult> LoginAsync(
        string userName,
        string password);

    Task<UserResult> GetUserByIdAsync(Guid id);

    Task<UserResult> GetUserByEmailAsync(string email);

    Task<UserResult> GetUserByUserNameAsync(string userName);

    Task<UserResult> UpdateUserAsync(
        Guid userId,
        string? userName,
        string? firstName,
        string? lastName);

    CookieOptions GetRemoveTokenFromCookieOptions();

    CookieOptions GetUserTokenCookieOptions();
}