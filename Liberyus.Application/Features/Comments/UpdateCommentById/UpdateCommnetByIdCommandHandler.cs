using AutoMapper;
using Liberyus.Domain.Entities;
using Liberyus.Domain.Repositories;
using MediatR;

namespace Liberyus.Application.Features.Comments.UpdateCommentById
{
    internal sealed class UpdateCommendByIdCommandHandler : IRequestHandler<UpdateCommendByIdCommand>
    {
        private readonly ICommendRepository _commentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCommendByIdCommandHandler(ICommendRepository commendRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _commentRepository = commendRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpdateCommendByIdCommand request, CancellationToken cancellationToken)
        {
           Comment? comment = await _commentRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.id, cancellationToken);
            if (comment is null)
            {
                throw new ArgumentException("yorum bulunamadı!");
            }

            if (comment.Title != request.Title)
            {
                var isCommentExists = await _commentRepository.AnyAsync(p => p.Title == request.Title, cancellationToken);

                if (isCommentExists)
                {
                    throw new ArgumentException("Bu yorum daha önce oluşturulmuş!");
                }
            }

            _mapper.Map(request, comment);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
          
        }
    }
}
