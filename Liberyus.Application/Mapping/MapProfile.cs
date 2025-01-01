using AutoMapper;
using Liberyus.Application.Features.Blogs.AddBlog;
using Liberyus.Application.Features.Blogs.UpdateBlog;
using Liberyus.Domain.Entities;


namespace Liberyus.Application.Mapping
{
    internal sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBlogCommand, Blog>().ReverseMap();
            CreateMap<UpdateBlogByIdCommand, Blog>().ReverseMap();
            
        }
    }
}
