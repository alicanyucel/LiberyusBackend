using Liberyus.Domain.Entities;
using MediatR;
using TS.Result;

namespace Liberyus.Application.Features.Comments.AddComment
{
  public sealed record AddCommentCommand(string Title,string Message): IRequest<Result<string>>;
}
