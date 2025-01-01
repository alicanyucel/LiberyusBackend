using AutoMapper;
using Liberyus.Application.Features.Blogs.AddBlog;
using Liberyus.Application.Features.Blogs.UpdateBlog;
using Liberyus.Application.Features.Comments.AddComment;
using Liberyus.Application.Features.Comments.UpdateCommentById;
using Liberyus.Domain.Entities;


namespace Liberyus.Application.Mapping
{
    internal sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCommendCommand, Blog>().ReverseMap();
            CreateMap<UpdateBlogByIdCommand, Blog>().ReverseMap();
            CreateMap<CreateCommentCommand, Comment>().ReverseMap();
            CreateMap<UpdateCommendByIdCommand, Comment>().ReverseMap();

        }
    }
}
