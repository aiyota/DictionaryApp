using DictionaryApp.Contracts.Authentication;
using DictionaryApp.Contracts;
using Microsoft.AspNetCore.Mvc;
using DictionaryApp.Application.Abstractions;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using DictionaryApp.Presentation.Api.Mapping;

namespace DictionaryApp.Presentation.Api.Controllers;

[Route("api/[controller]")]
public class AuthController : ApiControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public AuthController(
        IAuthenticationService authenticationService,
        IMapper mapper)
    {
        _authenticationService = authenticationService;
        _mapper = mapper;
    }

    [AllowAnonymous]
    [HttpPost(ApiRoutes.Auth.Register)]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var result = await _authenticationService.RegisterAsync(
            request.UserName,
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        SetTokenAsCookie(result.Token, result.CookieOptions);

        return Ok(_mapper.ResultToResponse(result));
    }

    [AllowAnonymous]
    [HttpPost(ApiRoutes.Auth.Login)]
    public async Task<ActionResult<AuthenticationResponse>> Login(LoginRequest request)
    {
        var result = await _authenticationService.LoginAsync(
            request.UserName,
            request.Password);

        SetTokenAsCookie(result.Token, result.CookieOptions);

        return Ok(_mapper.ResultToResponse(result));
    }

    [HttpGet(ApiRoutes.Auth.GetCurrentUser)]
    public async Task<ActionResult<UserResponse>> GetCurrentUser()
    {
        var result = await _authenticationService.GetUserByIdAsync(UserId ?? Guid.Empty);

        return Ok(_mapper.ResultToResponse(result));
    }

    [HttpPost(ApiRoutes.Auth.UpdateCurrentUser)]
    public async Task<ActionResult<UserResponse>> UpdateCurrentUser(UpdateRequest request)
    {
        var result = await _authenticationService.UpdateUserAsync(
            UserId ?? Guid.Empty,
            request.UserName,
            request.FirstName,
            request.LastName);

        return Ok(_mapper.ResultToResponse(result));
    }
}
