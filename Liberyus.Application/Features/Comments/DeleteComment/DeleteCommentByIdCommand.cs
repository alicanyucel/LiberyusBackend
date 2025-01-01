using MediatR;


namespace Liberyus.Application.Features.Comments.DeleteComment
{
    public sealed record DeleteCommentByIdCommand(int Id) : IRequest;
}
