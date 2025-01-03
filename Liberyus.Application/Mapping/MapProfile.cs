using AutoMapper;
using Liberyus.Application.Features.Blogs.AddBlog;
using Liberyus.Application.Features.Blogs.UpdateBlog;
using Liberyus.Application.Features.Comments.AddComment;
using Liberyus.Application.Features.Comments.UpdateComment;
using Liberyus.Domain.Entities;


namespace Liberyus.Application.Mapping
{
    internal sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCommentCommand, Blog>().ReverseMap(); // best practice two way mapping
            CreateMap<UpdateBlogByIdCommand, Blog>().ReverseMap();
            CreateMap<AddCommentCommand, Comment>().ReverseMap();
            CreateMap<UpdateCommentByIdCommand, Comment>().ReverseMap();

        }
    }
}
