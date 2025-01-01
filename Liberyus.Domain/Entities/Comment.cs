
using Liberyus.Domain.Abstractions;

namespace Liberyus.Domain.Entities
{
    public class Comment:Entity
    {
        //cay
        public string Title {  get; set; }
        public string Message { get; set; }
        public Blog Blog { get; set; }

        public static implicit operator Comment(Blog v)
        {
            throw new NotImplementedException();
        }
    }
}
