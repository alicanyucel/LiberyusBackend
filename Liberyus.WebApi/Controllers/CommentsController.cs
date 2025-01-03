using Liberyus.Application.Features.Comments.AddComment;
using Liberyus.Application.Features.Comments.DeleteCommentById;
using Liberyus.Application.Features.Comments.GetAllComment;
using Liberyus.Application.Features.Comments.GetCommentById;
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

  
    [HttpGet("{id:int}")] // success
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var request = new GetByIdCommentQuery(id);
        var result = await _mediator.Send(request);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }
    [HttpPost]   //   post error i'm looking error
    public async Task<IActionResult> Create([FromQuery]AddCommentCommand request, CancellationToken cancellationToken)
    {

        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
    [HttpDelete] // basarılı
    public async Task<IActionResult> DeleteCommentById(DeleteCommentByIdCommand request, CancellationToken cancellationToken)
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
