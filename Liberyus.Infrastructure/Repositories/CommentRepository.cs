using GenericRepository;
using Liberyus.Domain.Entities;
using Liberyus.Domain.Repositories;
using Liberyus.Infrastructure.Context;

namespace Liberyus.Infrastructure.Repositories;

internal sealed class CommentRepository : Repository<Comment, ApplicationDbContext>, ICommentRepository
{
    public CommentRepository(ApplicationDbContext context) : base(context)
    {
    }
}

