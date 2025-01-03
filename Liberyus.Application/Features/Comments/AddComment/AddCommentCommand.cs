using Liberyus.Domain.Entities;
using MediatR;
using TS.Result;

namespace Liberyus.Application.Features.Comments.AddComment
{
  public sealed record AddCommentCommand(Blog Blog,
      string Title,string Message): IRequest<Result<string>>;
}
