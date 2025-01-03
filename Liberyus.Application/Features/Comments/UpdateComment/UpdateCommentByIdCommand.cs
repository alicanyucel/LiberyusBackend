using MediatR;
using TS.Result;

namespace Liberyus.Application.Features.Comments.UpdateComment
{
    public sealed record UpdateCommentCommand(
         int Id,string Title,
        string Mesage):IRequest<Result<string>>;
}
