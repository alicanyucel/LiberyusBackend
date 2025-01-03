using Liberyus.Application.Features.Comments.AddComment;
using Liberyus.Application.Features.Comments.GetAllComment;
using Liberyus.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Liberyus.WebApi.Controllers;
[AllowAnonymous]
public class CommentsController : ApiController
{
    public CommentsController(IMediator mediator) : base(mediator)
    {
    }
 //   post error i'm looking error
    [HttpPost]
    public async Task<IActionResult> Create(AddCommentCommand request, CancellationToken cancellationToken)
    {

        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet] // success
    public async Task<IActionResult> GetAll([FromQuery] GetAllCommentQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);

    }
  
}
