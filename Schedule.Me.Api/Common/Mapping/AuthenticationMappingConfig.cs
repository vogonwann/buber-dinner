using Mapster;
using Schedule.Me.Application.Authentication.Commands.Register;
using Schedule.Me.Application.Authentication.Common;
using Schedule.Me.Application.Authentication.Queries.Login;
using Schedule.Me.Contracts.Authentication;

namespace Schedule.Me.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<LoginRequest, LoginQuery>();
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Token, src => src.Token)
                .Map(dest => dest, src => src.User);
        }
    }
}