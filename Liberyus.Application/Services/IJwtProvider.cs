using Liberyus.Application.Features.Auth.Login;
using Liberyus.Domain.Entities;

namespace Liberyus.Application.Services;


public interface IJwtProvider
{
    Task<LoginCommandResponse> CreateToken(AppUser user);
}