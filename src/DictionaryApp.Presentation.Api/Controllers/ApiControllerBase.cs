using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

namespace DictionaryApp.Presentation.Api.Controllers;

[ApiController]
public abstract class ApiControllerBase : ControllerBase
{

    /// <summary>
    /// Sets token as an HTTP Only cookie on the response.
    /// </summary>
    /// <param name="token">The token.</param>
    protected void SetTokenAsCookie(string token, CookieOptions cookieOptions)
    {
        Response.Cookies.Append("X-Access-Token", token, cookieOptions);
    }

    /// <summary>
    /// Removes token from cookies
    /// </summary>
    /// <param name="token">The token.</param>
    protected void RemoveTokenFromCookies(CookieOptions cookieOptions)
    {
        Response.Cookies.Append("X-Access-Token", "", cookieOptions);
    }

    [NonAction]
    public ActionResult Result(HttpStatusCode statusCode, string title)
    {
        HttpContext.Response.StatusCode = (int)statusCode;
        var traceId = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
        return new ObjectResult(new { Status = (int)statusCode, title, traceId });
    }

    [NonAction]
    public ActionResult NotFound(string title = "Resource was not found.")
    {
        return Result(HttpStatusCode.NotFound, title);
    }

    [NonAction]
    public ActionResult Unauthorized(string title = "You are not authorized to access this resource.")
    {
        return Result(HttpStatusCode.Unauthorized, title);
    }

    [NonAction]
    public ActionResult BadRequest(string title = "Invalid request.")
    {
        return Result(HttpStatusCode.BadRequest, title);
    }

    /// <summary>
    /// Shorthand for HttpContext.User.IsInRole(role)
    /// </summary>
    /// <param name="role">Name of role</param>
    protected bool UserIsInRole(string role) => HttpContext.User.IsInRole(role);

    /// <summary>
    /// Shorthand for !HttpContext.User.IsInRole(role)
    /// </summary>
    /// <param name="role">Name of role</param>
    protected bool UserIsNotInRole(string role) => !HttpContext.User.IsInRole(role);
}

