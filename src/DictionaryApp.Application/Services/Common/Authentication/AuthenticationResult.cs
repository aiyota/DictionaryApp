using DictionaryApp.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace DictionaryApp.Application.Services.Common.Authentication;

public record AuthenticationResult(
    User User,
    string Token,
    CookieOptions CookieOptions
);