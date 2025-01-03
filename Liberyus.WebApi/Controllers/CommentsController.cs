using Liberyus.Application.Features.Comments.AddComment;
using Liberyus.Application.Features.Comments.GetAllComment;
using Liberyus.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Liberyus.WebApi.Controllers;
[AllowAnonymous]
public class CommentsController : ApiController
{
    public CommentsController(IMediator mediator) : base(mediator)
    {
    }
   
    [HttpPost]
    public async Task<IActionResult> Create(AddCommentCommand request, CancellationToken cancellationToken)
    {

        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllCommentQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);

    }
  
}
