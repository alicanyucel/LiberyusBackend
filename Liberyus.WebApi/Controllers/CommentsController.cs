using Liberyus.WebApi.Abstractions;
using MediatR;

namespace Liberyus.WebApi.Controllers;


public class CommentsController : ApiController
{
    public CommentsController(IMediator mediator) : base(mediator)
    {
    }
}
