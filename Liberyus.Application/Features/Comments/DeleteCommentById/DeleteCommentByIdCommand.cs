using MediatR;
using TS.Result;

namespace Liberyus.Application.Features.Comments.DeleteCommentById
{
    public sealed record DeleteCommentByIdCommand(int Id) : IRequest<Result<string>>;
}
