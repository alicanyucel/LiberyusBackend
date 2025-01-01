using ErrorOr;
using MediatR;
using TS.Result;


namespace Liberyus.Application.Features.Blogs.AddBlog
{
  
    public sealed record CreateBlogCommand(
         string Title,
        string Content,
        DateTime UpdatedAt,
       DateTime CreatedAt
       ) : IRequest<Result<string>>;
}
