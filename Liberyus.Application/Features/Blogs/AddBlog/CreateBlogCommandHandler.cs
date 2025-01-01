using AutoMapper;
using ErrorOr;
using Liberyus.Domain.Entities;
using Liberyus.Domain.Repositories;
using MediatR;

namespace Liberyus.Application.Features.Blogs.AddBlog
{
    internal sealed class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, ErrorOr<Unit>>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBlogCommandHandler(IBlogRepository blogRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ErrorOr<Unit>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var isTitleExists = await _blogRepository.AnyAsync(p => p.Title == request.Title, cancellationToken);

            if (isTitleExists)
            {
                return Error.Conflict("IsTitleExists", "Bu blog daha önce oluşturulmuş!");
            }

            Blog blog = _mapper.Map<Blog>(request);

            await _blogRepository.AddAsync(blog, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
