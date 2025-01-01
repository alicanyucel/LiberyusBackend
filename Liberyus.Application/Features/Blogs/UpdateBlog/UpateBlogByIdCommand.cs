using MediatR;
using TS.Result;


namespace Liberyus.Application.Features.Blogs.UpdateBlog
{
    public sealed record UpdateBlogByIdCommand(
         int id,
         string Title,
         string Content,
         DateTime UpdatedAt,
         DateTime CreatedAt
    ) : IRequest<Result<string>>;
}
