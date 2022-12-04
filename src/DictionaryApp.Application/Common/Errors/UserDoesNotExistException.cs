using System.Net;

namespace DictionaryApp.Application.Common.Errors;

public class UserDoesNotExistException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.NotFound;

    public string ErrorMessage => "User does not exist.";
}