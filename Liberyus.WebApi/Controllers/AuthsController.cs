using Liberyus.Application.Features.Auth.Login;
using Liberyus.Application.Features.Auth.Register;
using Liberyus.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Liberyus.WebApi.Controllers;

[AllowAnonymous]
public sealed class AuthsController : ApiController
{
    public AuthsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
    [HttpPost]
    public async Task<IActionResult> Register([FromForm] RegisterCommand request, CancellationToken cancellationToken)
    {

        await _mediator.Send(request, cancellationToken);
        return NoContent();
    }
}