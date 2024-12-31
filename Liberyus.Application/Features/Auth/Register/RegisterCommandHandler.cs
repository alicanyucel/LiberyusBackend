using Liberyus.Domain.Entities;
using Liberyus.Domain.Events.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;


namespace Liberyus.Application.Features.Auth.Register;

internal sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand, Unit>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMediator _mediator;
    public RegisterCommandHandler(UserManager<AppUser> userManager, IMediator mediator)
    {
        _userManager = userManager;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var checkUserNameExists = await _userManager.FindByNameAsync(request.UserName);
        if (checkUserNameExists is not null)
        {
            throw new ArgumentException("Bu kullanıcı adı daha önce kullanılmış!");
        }

        var checkEmailExists = await _userManager.FindByEmailAsync(request.Email);
        if (checkEmailExists is not null)
        {
            throw new ArgumentException("Bu mail adresi daha önce kullanılmış!");
        }

        AppUser appUser = new()
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            UserName = request.UserName,
            PasswordHash = request.Password,
            PhoneNumber = request.PhoneNumber,
            
        };

        await _userManager.CreateAsync(appUser, request.Password);

        await _mediator.Publish(new UserDomainEvent(appUser));

        return Unit.Value;
    }
}
