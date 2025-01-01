using GenericRepository;
using Liberyus.Domain.Entities;

namespace Liberyus.Domain.Repositories
{
    public interface IBlogRepository : IRepository<Blog>
    {
        Task<Blog> GetByIdAsync(Func<object, bool> value, CancellationToken cancellationToken);
    }
}
