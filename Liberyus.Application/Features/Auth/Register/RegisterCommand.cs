using MediatR;

namespace Liberyus.Application.Features.Auth.Register
{
    public sealed record RegisterCommand(
      string Name,
      string Lastname,
      string Email,
      string UserName,
      string Password,
      string PhoneNumber
     ) : IRequest<Unit>;
}
