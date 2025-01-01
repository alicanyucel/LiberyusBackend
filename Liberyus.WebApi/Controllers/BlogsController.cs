using Liberyus.Application.Features.Blogs.AddBlog;
using Liberyus.Application.Features.Blogs.DeleteBlog;
using Liberyus.Application.Features.Blogs.GetAllBlog;
using Liberyus.Application.Features.Blogs.UpdateBlog;
using Liberyus.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Liberyus.WebApi.Controllers
{
    [AllowAnonymous]
    public class BlogsController : ApiController
    {
        public BlogsController(IMediator mediator) : base(mediator)
        {
        
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(id);
            return Ok(result);


        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogCommand request, CancellationToken cancellationToken)
        {

            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(GetAllBlogQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBlogById(DeleteBlogByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);

        }
        [HttpPut]
        public async Task<IActionResult> UpdateBlogById(UpdateBlogByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);

        }

    }
}
