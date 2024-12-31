using MediatR;
using TS.Result;

namespace Liberyus.Application.Features.Auth.Login
{
    public sealed record LoginCommand(
       string EmailOrUserName,
       string Password) : IRequest<Result<LoginCommandResponse>>;
}
