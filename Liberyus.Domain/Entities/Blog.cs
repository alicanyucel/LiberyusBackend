
using Liberyus.Domain.Abstractions;

namespace Liberyus.Domain.Entities
{
    public class Blog:Entity
    {
       
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<Comment> Comments { get; set; } // 1 to n relationship
    }
}
