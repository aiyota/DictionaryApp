using DictionaryApp.Application.Abstractions;
using DictionaryApp.Application.Common.Abstractions.Authentication;
using DictionaryApp.Application.Common.Errors;
using DictionaryApp.Application.Services.Common.Authentication;
using DictionaryApp.Domain.Abstractions;
using DictionaryApp.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace DictionaryApp.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserData _userData;
    private readonly ITokenGenerator _tokenGenerator;
    private readonly IHashingService _hashingService;

    public AuthenticationService(
        IUserData userData,
        ITokenGenerator tokenGenerator,
        IHashingService hashingService)
    {
        _userData = userData;
        _tokenGenerator = tokenGenerator;
        _hashingService = hashingService;
    }

    public async Task<AuthenticationResult> RegisterAsync(
        string userName,
        string firstName,
        string lastName,
        string email,
        string password)
    {
        if (await _userData.GetByUserNameAsync(userName) is not null
            || await _userData.GetByEmailAsync(email) is not null)
            throw new DuplicateUserException();

        var user = new User
        {
            UserName = userName,
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            PasswordHash = _hashingService.HashPassword(password),
        };

        var newUser = await _userData.CreateAsync(user);
        var token = _tokenGenerator.GenerateUserToken(newUser);
        var cookieOptions = _tokenGenerator.GetUserTokenCookieOptions();

        return new AuthenticationResult(newUser, token, cookieOptions);
    }

    public async Task<AuthenticationResult> LoginAsync(
        string userName,
        string password)
    {
        if (await _userData.GetByUserNameAsync(userName) is not User user)
            throw new UserDoesNotExistException();

        if (!_hashingService.VerifyPassword(user.PasswordHash, password))
            throw new NotAuthorizedException();

        var token = _tokenGenerator.GenerateUserToken(user);
        var cookieOptions = _tokenGenerator.GetUserTokenCookieOptions();

        return new AuthenticationResult(user, token, cookieOptions);
    }

    public async Task<UserResult> GetUserByIdAsync(Guid id)
    {
        if (await _userData.GetByIdAsync(id) is not User user)
            throw new UserDoesNotExistException();

        return new UserResult(user);
    }

    public Task<UserResult> GetUserByUserNameAsync(string userName)
    {
        throw new NotImplementedException();
    }

    public Task<UserResult> GetUserByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<UserResult> UpdateUserAsync(
        Guid userId,
        string? userName,
        string? firstName,
        string? lastName)
    {
        if (await _userData.GetByIdAsync(userId) is null)
            throw new UserDoesNotExistException();

        var updatedUser = await _userData.UpdateAsync(
            userId,
            userName,
            firstName,
            lastName);
        
        return new UserResult(updatedUser);
    }

    public CookieOptions GetRemoveTokenFromCookieOptions() =>
        _tokenGenerator.GetRemoveTokenFromCookieOptions();

    public CookieOptions GetUserTokenCookieOptions() =>
        _tokenGenerator.GetUserTokenCookieOptions();
}
