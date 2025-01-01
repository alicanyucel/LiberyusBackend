using MediatR;

namespace Liberyus.Application.Features.Blogs.DeleteBlog
{
    public sealed record DeleteBlogByIdCommand(int Id) : IRequest;
}
