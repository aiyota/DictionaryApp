using DictionaryApp.Application.Common.Abstractions.Authentication;
using DictionaryApp.Domain.Common.Authentication;
using DictionaryApp.Domain.Common.Claims;
using DictionaryApp.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DictionaryApp.Infrastructure.Authentication;

public class JwtTokenGenerator : ITokenGenerator
{
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IOptions<JwtSettings> jwtOptions)
    {
        _jwtSettings = jwtOptions.Value;
    }

    public string GenerateUserToken(User user)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256
        );

        var claims = new List<Claim>()
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(CustomClaims.EmailConfirmed,
                user.EmailedConfirmed.ToString())
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            claims: claims,
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }

    public CookieOptions GetUserTokenCookieOptions()
    {
        return new CookieOptions()
        {
            HttpOnly = true,
            SameSite = SameSiteMode.None,
            Expires = DateTime.Now.AddMinutes(_jwtSettings.ExpiryMinutes),
            Secure = true
        };
    }

    public CookieOptions GetRemoveTokenFromCookieOptions()
    {
        return new CookieOptions()
        {
            HttpOnly = true,
            SameSite = SameSiteMode.None,
            Expires = DateTime.Now.AddDays(-1),
            Secure = true

        };
    }
}
