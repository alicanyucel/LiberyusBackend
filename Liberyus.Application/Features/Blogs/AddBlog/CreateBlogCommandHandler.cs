using AutoMapper;
using Liberyus.Domain.Entities;
using Liberyus.Domain.Repositories;
using MediatR;
using TS.Result;

namespace Liberyus.Application.Features.Blogs.AddBlog
{
    internal sealed class CreateBlogCommandHandler(IBlogRepository blogRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateBlogCommand, Result<string>>
    {
        public IBlogRepository BlogRepository { get; } = blogRepository;

        public async Task<Result<string>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
           Blog blog  = mapper.Map<Blog>(request);

            await BlogRepository.AddAsync(blog, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Blog Added";
        }
    }
}
