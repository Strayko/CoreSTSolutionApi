using AutoMapper;
using CoreSTSolutionApi.Data.Entities;
using CoreSTSolutionApi.Models;

namespace CoreSTSolutionApi.Data
{
    public class BlogProfile : Profile
    {
        public BlogProfile()
        {
            this.CreateMap<Blog, BlogModel>();
        }
    }
}