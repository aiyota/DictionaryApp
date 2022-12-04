using DictionaryApp.Contracts.Authentication;
using DictionaryApp.Contracts;
using Microsoft.AspNetCore.Mvc;
using DictionaryApp.Application.Abstractions;
using Microsoft.AspNetCore.Authorization;

namespace DictionaryApp.Presentation.Api.Controllers;

[Route("api/[controller]")]
public class AuthController : ApiControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost(ApiRoutes.Auth.Register)]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var result = await _authenticationService.Register(
            request.UserName,
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        SetTokenAsCookie(result.Token, result.CookieOptions);

        return Ok();
    }

    [AllowAnonymous]
    [HttpPost(ApiRoutes.Auth.Login)]
    public async Task<ActionResult<AuthenticationResponse>> Login(LoginRequest request)
    {
        var result = await _authenticationService.Login(
            request.UserName,
            request.Password);

        SetTokenAsCookie(result.Token, result.CookieOptions);

        return Ok();
    }
}
