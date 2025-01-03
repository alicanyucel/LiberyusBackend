using Liberyus.Domain.Entities;
using Liberyus.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Liberyus.Application.Features.Comments.GetCommentById
{
    internal sealed class GetByIdCommentQueryHandler : IRequestHandler<GetByIdCommentQuery, Comment>
    {
        private readonly ICommentRepository _commentRepository;

        public GetByIdCommentQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Comment> Handle(GetByIdCommentQuery request, CancellationToken cancellationToken)
        {
            return await _commentRepository.GetAll().FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
        }
    }
}
