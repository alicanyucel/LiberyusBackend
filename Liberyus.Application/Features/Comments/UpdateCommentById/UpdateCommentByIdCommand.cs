using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberyus.Application.Features.Comments.UpdateCommentById
{
    public sealed record UpdateCommendByIdCommand(
        int id,
        string Title,
        string Message
   ) : IRequest;
}
