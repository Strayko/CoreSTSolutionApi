using AutoMapper;
using CoreSTSolutionApi.Data.Entities;
using CoreSTSolutionApi.Models;

namespace CoreSTSolutionApi.Data
{
    public class BlogProfile : Profile
    {
        public BlogProfile()
        {
            this.CreateMap<Blog, BlogModel>()
                .ForMember(c=>c.Category, o 
                    => o.MapFrom(m=>m.Category.CategoryName))
                .ForMember(c=>c.Description, o
                    => o.MapFrom(m=>m.Category.Description));
        }
    }
}