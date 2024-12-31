using AutoMapper;


namespace Liberyus.Application.Mapping
{
    internal sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBlogCommand, Blog>().ReverseMap();
            CreateMap<UpdateBlogCommand, Blog>().ReverseMap();
          
        }
    }
}
