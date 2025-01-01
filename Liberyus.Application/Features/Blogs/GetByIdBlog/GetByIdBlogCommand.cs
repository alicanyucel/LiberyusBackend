using Liberyus.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberyus.Application.Features.Blogs.GetByIdBlog
{
    public sealed record GetBlogByIdQuery(int Id) : IRequest<Blog>;
}
