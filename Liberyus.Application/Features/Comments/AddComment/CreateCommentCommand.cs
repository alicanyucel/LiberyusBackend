using ErrorOr;
using MediatR;

namespace Liberyus.Application.Features.Comments.AddComment
{
    public sealed record CreateCommentCommand(
          string Message,string Title
          ) : IRequest<ErrorOr<Unit>>;
}
