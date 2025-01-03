using Liberyus.Domain.Entities;
using MediatR;


namespace Liberyus.Application.Features.Comments.GetAllComment
{
    public sealed record GetAllCommentQuery() : IRequest<List<Comment>>;
}
