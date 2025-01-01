using AutoMapper;
using Liberyus.Domain.Entities;
using Liberyus.Domain.Repositories;
using MediatR;
using TS.Result;

namespace Liberyus.Application.Features.Blogs.UpdateBlog
{
    internal sealed class UpdateBlogByIdCommandHandler(IBlogRepository blogRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateBlogByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateBlogByIdCommand request, CancellationToken cancellationToken)
        {
            Blog blog = await blogRepository.GetByExpressionWithTrackingAsync(P => P.Id == request.id, cancellationToken);
            if (blog == null)
            {
                return Result<string>.Failure("blog not found");
            }
            mapper.Map(request, blog);
            blogRepository.Update(blog);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Blog update is successful";

        }
    }
}
