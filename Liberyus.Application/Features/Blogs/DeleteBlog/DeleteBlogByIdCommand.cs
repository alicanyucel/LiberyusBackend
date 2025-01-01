using MediatR;
using TS.Result;

namespace Liberyus.Application.Features.Blogs.DeleteBlog
{
    public sealed record DeleteBlogByIdCommand(int Id) : IRequest<Result<string>>;
}
