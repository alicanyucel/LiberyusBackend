using Liberyus.Domain.Entities;
using Liberyus.Domain.Repositories;
using MediatR;
using TS.Result;

namespace Liberyus.Application.Features.Comments.DeleteCommentById
{
    internal sealed class DeleteCommentByIdCommandHandler(
       ICommentRepository commentRepository,
      IUnitOfWork unitOfWork) : IRequestHandler<DeleteCommentByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteCommentByIdCommand request, CancellationToken cancellationToken)
        {
            Comment comment = await commentRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
            if (comment is null)
            {
                return Result<string>.Failure("Comment not found");
            }

            commentRepository.Delete(comment);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Comment delete is successful";
        }
    }
}
