using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoreSTSolutionApi.Data;
using CoreSTSolutionApi.Data.Entities;
using CoreSTSolutionApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace CoreSTSolutionApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public BlogsController(IBlogRepository blogRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
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

        [HttpGet("search")]
        public async Task<ActionResult<BlogModel[]>> SearchByName(string name)
        {
            try
            {
                var results = await _blogRepository.GetAllBlogsByName(name);
                if (!results.Any()) return NotFound();
                return _mapper.Map<BlogModel[]>(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
        
        public async Task<ActionResult<Blog>> Post(Blog model)
        {
            try
            {
                var blog = await _blogRepository.IsUnique(model.Name);
                if (blog != null)
                {
                    return BadRequest("Name in Use");
                }

                _blogRepository.Add(model);
                if (await _blogRepository.SaveChangesAsync())
                {
                    return Created($"/api/blogs/{model.BlogId}", model);
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();
        }
    }
}