using ErrorOr;
using MediatR;


namespace Liberyus.Application.Features.Blogs.AddBlog
{
    public sealed record CreateCommendCommand(
         string Title,
         string Content,
         DateTime UpdatedAt,
         DateTime CreatedAt
        ) : IRequest<ErrorOr<Unit>>;
}
