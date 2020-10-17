using AutoMapper;
using CoreSTSolutionApi.Data.Entities;
using CoreSTSolutionApi.Models;

namespace CoreSTSolutionApi.Data
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            this.CreateMap<Tag, TagModel>()
                .ForMember(c => c.TagId, o
                    => o.MapFrom(m => m.TagId))
                .ForMember(c => c.Name, o
                    => o.MapFrom(c => c.Name));
        }
    }
}