using ErrorOr;
using MediatR;


namespace Liberyus.Application.Features.Blogs.AddBlog
{
    public sealed record CreatBlogCommand(
         string Title,
         string Content,
         DateTime UpdatedAt,
         DateTime CreatedAt
        ) : IRequest<ErrorOr<Unit>>;
}
