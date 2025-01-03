using AutoMapper;
using Liberyus.Domain.Entities;
using Liberyus.Domain.Repositories;
using MediatR;
using TS.Result;

namespace Liberyus.Application.Features.Comments.AddComment
{

    internal sealed class AddCommentCommandHandler(ICommentRepository commentRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<AddCommentCommand, Result<string>>
    {
        public ICommentRepository CommentRepository { get; } = commentRepository;

        public async Task<Result<string>> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            Comment comment = mapper.Map<Comment>(request);

            await CommentRepository.AddAsync(comment, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Comment Added";
        }
    }
}
