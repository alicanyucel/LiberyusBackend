using Liberyus.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberyus.Application.Features.Comments.GetCommentById
{
    public sealed record GetByIdCommentQuery(int Id) : IRequest<Comment>;
}
