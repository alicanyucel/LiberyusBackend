using AutoMapper;
using ErrorOr;
using Liberyus.Application.Features.Blogs.AddBlog;
using Liberyus.Domain.Entities;
using Liberyus.Domain.Repositories;
using MediatR;

namespace Liberyus.Application.Features.Comments.AddComment
{
    internal sealed class CreateCommendCommandHandler : IRequestHandler<CreateCommendCommand, ErrorOr<Unit>>
    {
        private readonly ICommentRepository _commendRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCommendCommandHandler(ICommentRepository commendRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _commendRepository =commendRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ErrorOr<Unit>> Handle(CreateCommendCommand request, CancellationToken cancellationToken)
        {
            var isTitleExists = await _commendRepository.AnyAsync(p => p.Title == request.Title, cancellationToken);

            if (isTitleExists)
            {
                return Error.Conflict("IsTitleExists", "Bu yorum daha önce oluşturulmuş!");
            }

            Comment comment = _mapper.Map<Comment>(request);

            await _commendRepository.AddAsync(comment, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
