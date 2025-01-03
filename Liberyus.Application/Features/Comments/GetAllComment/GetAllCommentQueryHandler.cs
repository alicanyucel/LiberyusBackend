using Liberyus.Domain.Entities;
using Liberyus.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Liberyus.Application.Features.Comments.GetAllComment
{
    internal sealed class GetAllCommentQueryHandler : IRequestHandler<GetAllCommentQuery, List<Comment>>
    {
        private readonly ICommentRepository _commentRepository;

        public GetAllCommentQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<List<Comment>> Handle(GetAllCommentQuery request, CancellationToken cancellationToken)
        {
            return await _commentRepository.GetAll().OrderBy(p => p.Title).ToListAsync(cancellationToken);
        }
    }
}
