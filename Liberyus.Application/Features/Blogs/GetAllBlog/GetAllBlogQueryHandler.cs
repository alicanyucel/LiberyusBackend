using Liberyus.Domain.Entities;
using Liberyus.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Liberyus.Application.Features.Blogs.GetAllBlog
{
    internal sealed class GetAllBlogQueryHandler : IRequestHandler<GetAllBlogQuery, List<Blog>>
    {
        private readonly ICommendRepository _blogRepository;

        public GetAllBlogQueryHandler(ICommendRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<Blog>> Handle(GetAllBlogQuery request, CancellationToken cancellationToken)
        {
            return await _blogRepository.GetAll().OrderBy(p => p.Title).ToListAsync(cancellationToken);
        }
    }
}
