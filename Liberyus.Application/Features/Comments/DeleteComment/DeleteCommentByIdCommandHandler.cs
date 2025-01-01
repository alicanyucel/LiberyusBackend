using GenericRepository;
using Liberyus.Domain.Repositories;
using MediatR;
using TS.Result;


namespace Liberyus.Application.Features.Comments.DeleteComment
{
    internal sealed class DeleteCommentByIdCommandHandler(
     ICommentRepository commentRepository,
     IUnitOfWork unitOfWork) : IRequestHandler<DeleteCommentByIdCommand, Result<string>>
    {
        private readonly ICommendRepository _commentRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCommentByIdCommandHandler(ICommendRepository commentRepository, Domain.Repositories.IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }

     
        public Task<Result<string>> Handle(DeleteCommentByIdCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
