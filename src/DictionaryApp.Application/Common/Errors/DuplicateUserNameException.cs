using System.Net;

namespace DictionaryApp.Application.Common.Errors;

internal class DuplicateUserException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

    public string ErrorMessage => "Account with this username and/or email already exists.";
}
