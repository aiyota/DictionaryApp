using AutoMapper;
using DictionaryApp.Application.Services.Common.Authentication;
using DictionaryApp.Contracts.Authentication;

namespace DictionaryApp.Presentation.Api.Mapping;

public static class MapperExtensions
{
    public static AuthenticationResponse ResultToResponse(this IMapper mapper, AuthenticationResult result) =>
        mapper.Map<AuthenticationResponse>(result);

    public static UserResponse ResultToResponse(this IMapper mapper, UserResult result) =>
        mapper.Map<UserResponse>(result);
}
