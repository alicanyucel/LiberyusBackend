using MediatR;


namespace Liberyus.Application.Features.Blogs.UpdateBlog
{
    public sealed record UpdateBlogByIdCommand(
         int id,
         string Title,
         string Content,
         DateTime UpdatedAt,
         DateTime CreatedAt
    ) : IRequest;
}
