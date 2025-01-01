using GenericRepository;
using Liberyus.Domain.Entities;
using Liberyus.Domain.Repositories;
using Liberyus.Infrastructure.Context;

namespace Liberyus.Infrastructure.Repositories;

internal sealed class BlogRepository : Repository<Blog, ApplicationDbContext>,ICommendRepository
{
    public BlogRepository(ApplicationDbContext context) : base(context)
    {
    }

    
}
