using DictionaryApp.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace DictionaryApp.Application.Common.Abstractions.Authentication;

public interface ITokenGenerator
{
    string GenerateUserToken(User user);
    CookieOptions GetUserTokenCookieOptions();
    CookieOptions GetRemoveTokenFromCookieOptions();
}