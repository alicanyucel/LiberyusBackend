using Liberyus.Domain.Entities;
using Liberyus.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Liberyus.Application.Features.Blogs.GetByIdBlog
{
    internal sealed class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, Blog>
    {
        private readonly IBlogRepository _blogRepository;

        public GetBlogByIdQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<Blog> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            return await _blogRepository.GetAll()
                .FirstOrDefaultAsync(blog => blog.Id == request.Id, cancellationToken);
        }
    }

}
