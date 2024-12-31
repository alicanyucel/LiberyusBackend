using Liberyus.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Liberyus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ApiController
    {
        public BlogsController(IMediator mediator) : base(mediator)
        {
        }
    }
}
