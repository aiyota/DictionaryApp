using System.Net;

namespace DictionaryApp.Application.Common.Errors;
public class NotAuthorizedException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;

    public string ErrorMessage => "You are not authorized to access this";
}
