using AutoMapper;
using DictionaryApp.Application.Services.Common.Authentication;
using DictionaryApp.Contracts.Authentication;

namespace DictionaryApp.Presentation.Api.Mapping.Profiles;

public class AuthenticationProfile : Profile
{
    public AuthenticationProfile()
    {
        CreateMap<AuthenticationResult, AuthenticationResponse>()
            .ForCtorParam(nameof(AuthenticationResponse.Id),
                          opt => opt.MapFrom(src => src.User.Id))
            .ForCtorParam(nameof(AuthenticationResponse.UserName),
                          opt => opt.MapFrom(src => src.User.UserName))
            .ForCtorParam(nameof(AuthenticationResponse.FirstName),
                          opt => opt.MapFrom(src => src.User.FirstName))
            .ForCtorParam(nameof(AuthenticationResponse.LastName),
                          opt => opt.MapFrom(src => src.User.LastName))
            .ForCtorParam(nameof(AuthenticationResponse.Email),
                          opt => opt.MapFrom(src => src.User.Email));
    }
}
