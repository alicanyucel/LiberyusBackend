using GenericRepository;
using Liberyus.Domain.Entities;
using Liberyus.Domain.Repositories;
using MediatR;
using TS.Result;

namespace Liberyus.Application.Features.Blogs.DeleteBlog
{
    internal sealed class DeleteBlogByIdCommandHandler(
     IBlogRepository boatRepository,
    Domain.Repositories.IUnitOfWork unitOfWork) : IRequestHandler<DeleteBlogByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteBlogByIdCommand request, CancellationToken cancellationToken)
        {
            Blog blog = await boatRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
            if (blog is null)
            {
                return Result<string>.Failure("Blog not found");
            }

            boatRepository.Delete(blog);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Blog delete is successful";
        }
    }
}
