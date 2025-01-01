using Liberyus.Domain.Entities;
using MediatR;

namespace Liberyus.Application.Features.Blogs.GetAllBlog
{
    public sealed record GetAllBlogQuery() : IRequest<List<Blog>>;
}
