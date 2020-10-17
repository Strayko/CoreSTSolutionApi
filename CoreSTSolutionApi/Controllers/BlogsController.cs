using System;
using System.Threading.Tasks;
using AutoMapper;
using CoreSTSolutionApi.Data;
using CoreSTSolutionApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreSTSolutionApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public BlogsController(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<BlogModel[]>> Get(bool includeTags = false)
        {
            try
            {
                var results = await _blogRepository.GetAllBlogsAsync(includeTags);
                
                BlogModel[] models = _mapper.Map<BlogModel[]>(results);
                return models;
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("{blogId}")]
        public async Task<ActionResult<BlogModel>> Get(int blogId)
        {
            try
            {
                var result = await _blogRepository.GetBlogAsync(blogId);
                if (result == null) return NotFound();
                return _mapper.Map<BlogModel>(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
    }
}