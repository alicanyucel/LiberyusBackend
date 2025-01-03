using AutoMapper;
using Liberyus.Domain.Entities;
using Liberyus.Domain.Repositories;
using MediatR;
using TS.Result;

namespace Liberyus.Application.Features.Comments.UpdateComment;

internal sealed class UpdateCommentByIdCommandHandler(ICommentRepository commentRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateCommentCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        Comment? comment = await commentRepository.GetByExpressionWithTrackingAsync(P => P.Id == request.Id, cancellationToken);
        if (comment == null)
        {
            return Result<string>.Failure("comment not found");
        }
        mapper.Map(request, comment);
        commentRepository.Update(comment);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return "Comment update is successful";

    }
}
