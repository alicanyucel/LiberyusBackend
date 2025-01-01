using Liberyus.Domain.Entities;
using Liberyus.Domain.Repositories;
using MediatR;

namespace Liberyus.Application.Features.Blogs.DeleteBlog
{
    internal sealed class DeleteBlogByIdCommandHandler : IRequestHandler<DeleteBlogByIdCommand>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteBlogByIdCommandHandler(IBlogRepository blogRepository, IUnitOfWork unitOfWork)
        {
            _blogRepository = blogRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteBlogByIdCommand request, CancellationToken cancellationToken)
        {
            Blog? blog = await _blogRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);
            if (blog is null)
            {
                throw new ArgumentException("Blog bulunamadı!");
            }
        }
    }
}
