
using Liberyus.Domain.Abstractions;

namespace Liberyus.Domain.Entities
{
    public class Comment:Entity
    {
        //cay
        public string Message { get; set; }
        public Blog Blog { get; set; }
    }
}
