using System.Net;

namespace DictionaryApp.Application.Common.Errors;

internal class DuplicateUserNameException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

    public string ErrorMessage => "Account with this username already exists.";
}
