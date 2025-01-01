using AutoMapper;
using Liberyus.Domain.Entities;
using Liberyus.Domain.Repositories;
using MediatR;

namespace Liberyus.Application.Features.Blogs.UpdateBlog
{
    internal sealed class UpdateBlogByIdCommandHandler : IRequestHandler<UpdateBlogByIdCommand>
    {
        private readonly ICommendRepository _blogRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBlogByIdCommandHandler(ICommendRepository blogRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpdateBlogByIdCommand request, CancellationToken cancellationToken)
        {
            Blog? blog = await _blogRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.id, cancellationToken);
            if (blog is null)
            {
                throw new ArgumentException("Blog bulunamadı!");
            }

            if (blog.Title != request.Title)
            {
                var isBlogExists = await _blogRepository.AnyAsync(p => p.Title == request.Title, cancellationToken);

                if (isBlogExists)
                {
                    throw new ArgumentException("Bu blog daha önce oluşturulmuş!");
                }
            }

            _mapper.Map(request, blog);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}